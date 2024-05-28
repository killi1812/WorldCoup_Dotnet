using FootballData.Api;
using FootballData.Data.Models;
using FootballData.ProjectSettings;

namespace FormGui
{
    public partial class Form1 : Form
    {
        public IEnumerable<string> teams { get; set; }

        private IFootballRepository repo;
        public Form1()
        {
            SetLengauge();
            InitializeComponent();
            repo = FootballRepositoryFactory.GetRepository(1);
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void SetLengauge()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Settings.GetSettings().Values.Language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.GetSettings().Values.Language);
        }
        private async Task RefreshAsync()
        {
            SetLengauge();
            this.Controls.Clear();
            InitializeComponent();
            await rangListView1.RefreshAsync();
            await LoadTeams();
        }
        private async void MainForm_Show(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            if (settings.IsNew)
            {
                SettingsForm settingsForm = new();
                settingsForm.ShowDialog();
            }
            await LoadTeams();
        }
        private async void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            settings.Values.FavoritePlayers = await favoritePlayerView1.GetFavortePlayers();
            await settings.SaveSettingsAsync();
            await LoadTeams();
            await RefreshAsync();
        }

        private async void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new();
            var response = settingsForm.ShowDialog();
            if (response == DialogResult.OK)
            {
                await LoadTeams();
                await RefreshAsync();
            }
        }
        private async Task LoadTeams()
        {
            var teams = await fetchTeams();
            cmbRep.Items.AddRange(teams.ToArray());
            Settings settings = Settings.GetSettings();
            cmbRep.SelectedItem = settings.Values.FavoritTimeFifaCode;
        }

        private async Task<IOrderedEnumerable<string>> fetchTeams()
        {
            try
            {
                cmbRep.Items.Clear();
                Settings settings = Settings.GetSettings();
                return (await repo.GetTeams()).Select(t => t.FifaCode).Order();
            }
            catch (Exception err)
            {
                using Form form = new Error(err.Message);
                form.ShowDialog();
            }
            return null;
        }

        private async void cmbRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            string team = cmbRep.SelectedItem.ToString()!;
            settings.Values.FavoritTimeFifaCode = team;
            await favoritePlayerView1.SetTeam(team);
            await attendenceView1.SetTeam(team);
            await rangListView1.SetTeam(team);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = tabs.SelectedIndex;
            var tab = tabs.Controls[index];

            if(tab.Controls[0] is IPrintable printable)
            {
                printable.Print();
            }
        }

        private void prToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
