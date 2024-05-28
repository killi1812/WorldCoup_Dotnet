using FootballData.Api;
using FootballData.Data.Enums;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System.Data;

namespace FormGui
{
    public partial class RangListView : UserControl, IPrintable
    {
        public RangListView()
        {
            InitializeComponent();
            //TODO null check
            repo = FootballRepositoryFactory.GetRepository(Settings.GetSettings().Values.Repository);
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
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = "";
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                text += $"\n{item.Text}";
            }

            e.Graphics.DrawString(text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
        }
    }
}
