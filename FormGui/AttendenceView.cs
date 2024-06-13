using FootballData.Api;
using FootballData.ProjectSettings;
using System.ComponentModel;
using System.Data;

namespace FormGui
{
    [ToolboxItem(true)]
    public partial class AttendenceView : UserControl, IPrintable
    {
        public AttendenceView()
        {
            InitializeComponent();
            repo = FootballRepositoryFactory.GetRepository(AppRepo.GetSettings().Values.Repository);
        }
        private IFootballRepository repo;
        public string? team;

        public async Task SetTeam(string team)
        {
            flowLayoutPanel1.Controls.Clear();
            if (this.team == team) return;
            this.team = team;
            await GetAttendence();
        }

        public async Task GetAttendence()
        {
            var matches = await repo.GetMatchesByCountry(team);
            List<string> strings = matches
                .OrderByDescending(m => m.Attendance)
                .Select(m => $"{m.Location}, {m.Venue} ({m.Attendance}) - {m.HomeTeamCountry} vs {m.AwayTeamCountry}")
                .ToList();

            List<Label> labels = new List<Label>();
            foreach (var match in strings)
            {
                var label = new Label()
                {
                    Text = match,
                    Width = 400
                };
                labels.Add(label);
            }
            flowLayoutPanel1.Controls.AddRange(labels.ToArray());
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

        public void Print()
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
