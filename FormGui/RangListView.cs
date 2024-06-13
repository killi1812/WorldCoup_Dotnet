using FootballData.Api;
using FootballData.Data.Enums;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace FormGui
{
    public partial class RangListView : UserControl, IPrintable
    {
        public RangListView()
        {
            InitializeComponent();
            //TODO null check
            repo = FootballRepositoryFactory.GetRepository(AppRepo.GetSettings().Values.Repository);
        }
        private IFootballRepository repo;
        public string? team;

        public async Task SetTeam(string team)
        {
            if (this.team == team) return;
            this.team = team;
            await GetPlayers();
        }
        public async Task RefreshAsync()
        {
            Controls.Clear();
            InitializeComponent();
            await GetPlayers();
        }

        private async Task GetPlayers()
        {
            if (team == null || team == "")
                return;

            IEnumerable<Match> matches = await repo.GetMatchesByCountry(team);
            IOrderedEnumerable<Player> players = matches
                .Where(m => m.HomeTeamResult.FifaCode == team)
                .Select(m => m.HomeTeamStatistics)
                .SelectMany(s => s.StartingEleven.Concat(s.Substitutes))
                .Union(
                    matches.Where(m => m.AwayTeamResult.FifaCode == team)
                    .Select(m => m.AwayTeamStatistics)
                    .SelectMany(s => s.StartingEleven.Concat(s.Substitutes))
                    )
                .DistinctBy(p => p.ShirtNumber)
                .OrderBy(p => p.Name);

            var stats = matches
                .SelectMany(m => m.AwayTeamEvents)
                .Union(
                    matches
                    .SelectMany(m => m.HomeTeamEvents)
                    )
                .Where(e => e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.YellowCard || e.TypeOfEvent == TypeOfEvent.YellowCardSecond)
                .ToList();

            List<KeyValuePair<Player, (int, int)>> statsFroPlayer = new List<KeyValuePair<Player, (int, int)>>();

            foreach (Player player in players)
            {
                var statsForPlayer = stats.Where(s => s.Player == player.Name).ToList();
                statsFroPlayer.Add(new KeyValuePair<Player, (int, int)>(player, (statsForPlayer.Count(i => i.TypeOfEvent == TypeOfEvent.Goal), statsForPlayer.Count(i => i.TypeOfEvent == TypeOfEvent.YellowCard || i.TypeOfEvent == TypeOfEvent.YellowCardSecond))));
            }

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            List<PlayerLabel> goals = new List<PlayerLabel>();
            List<PlayerLabel> cards = new List<PlayerLabel>();

            statsFroPlayer = statsFroPlayer.OrderByDescending(e => e.Value.Item1).ToList();
            foreach (var player in statsFroPlayer)
            {
                var goal = new PlayerLabel(player.Key.Name, player.Key.ShirtNumber, player.Key.Captain, $"Goals: {player.Value.Item1}");
                goals.Add(goal);
            }
            flowLayoutPanel1.Controls.AddRange(goals.ToArray());

            statsFroPlayer = statsFroPlayer.OrderByDescending(e => e.Value.Item2).ToList();
            foreach (var player in statsFroPlayer)
            {
                var card = new PlayerLabel(player.Key.Name, player.Key.ShirtNumber, player.Key.Captain, $"YellowCards: {player.Value.Item2}");
                cards.Add(card);
            }
            flowLayoutPanel2.Controls.AddRange(cards.ToArray());
        }

        public void Print()
        {
            StringBuilder text = new StringBuilder();
            foreach (PlayerLabel item in flowLayoutPanel1.Controls)
            {
                text.AppendLine(item.Text);
            }
            text.AppendLine();
            foreach (PlayerLabel item in flowLayoutPanel2.Controls)
            {
                text.AppendLine(item.Text);
            }

            PrintDocument p = printDocument1; 

            var font = new Font("Times New Roman", 12);
            var margins = p.DefaultPageSettings.Margins;
            var layoutArea = new RectangleF(
                margins.Left,
                margins.Top,
                p.DefaultPageSettings.PrintableArea.Width - (margins.Left + margins.Right),
                p.DefaultPageSettings.PrintableArea.Height - (margins.Top + margins.Bottom));
            var layoutSize = layoutArea.Size;
            layoutSize.Height = layoutSize.Height - font.GetHeight(); // keep lastline visible
            var brush = new SolidBrush(Color.Black);

            var remainingText = text.ToString();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                int charsFitted, linesFilled;

                // measure how many characters will fit of the remaining text
                var realsize = e1.Graphics.MeasureString(
                    remainingText,
                    font,
                    layoutSize,
                    StringFormat.GenericDefault,
                    out charsFitted,  // this will return what we need
                    out linesFilled);

                // take from the remainingText what we're going to print on this page
                var fitsOnPage = remainingText.Substring(0, charsFitted);
                // keep what is not printed on this page 
                remainingText = remainingText.Substring(charsFitted).Trim();

                // print what fits on the page
                e1.Graphics.DrawString(
                    fitsOnPage,
                    font,
                    brush,
                    layoutArea);

                // if there is still text left, tell the PrintDocument it needs to call 
                // PrintPage again.
                e1.HasMorePages = remainingText.Length > 0;
            };

            p.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var font = new Font("Times New Roman", 12);
            var margins = printDocument1.DefaultPageSettings.Margins;
            var layoutArea = new RectangleF(
                margins.Left,
                margins.Top,
                printDocument1.DefaultPageSettings.PrintableArea.Width - (margins.Left + margins.Right),
               printDocument1.DefaultPageSettings.PrintableArea.Height - (margins.Top + margins.Bottom));
            var layoutSize = layoutArea.Size;
            layoutSize.Height = layoutSize.Height - font.GetHeight(); // keep lastline visible
            var brush = new SolidBrush(Color.Black);

            // what still needs to be printed
            var remainingText = "";

            int charsFitted, linesFilled;

            // measure how many characters will fit of the remaining text
            var realsize = e.Graphics.MeasureString(
            remainingText,
                font,
                layoutSize,
                StringFormat.GenericDefault,
                out charsFitted,  // this will return what we need
                out linesFilled);

            // take from the remainingText what we're going to print on this page
            var fitsOnPage = remainingText.Substring(0, charsFitted);
            // keep what is not printed on this page 
            remainingText = remainingText.Substring(charsFitted).Trim();

            // print what fits on the page
            e.Graphics.DrawString(
            fitsOnPage,
            font,
                brush,
                layoutArea);

            // if there is still text left, tell the PrintDocument it needs to call 
            // PrintPage again.
            e.HasMorePages = remainingText.Length > 0;

            //TODO add another page
        }
    }
}
