using FootballData.Api;
using FootballData.ProjectSettings;
using System.ComponentModel;
using System.Data;

namespace FormGui
{
    [ToolboxItem(true)]
    public partial class AttendenceView : UserControl
    {
        public AttendenceView()
        {
            InitializeComponent();
            repo = FootballRepositoryFactory.GetRepository(Settings.GetSettings().Values.Repository);
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
    }
}
