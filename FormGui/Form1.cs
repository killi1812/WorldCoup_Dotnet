using FootballData.Api;
using FootballData.ProjectSettings;

namespace FormGui
{
    public partial class Form1 : Form
    {
        public IEnumerable<string> teams { get; set; }

        private IFootballRepository repo;
        public Form1()
        {
            InitializeComponent();
            repo = FootballRepositoryFactory.GetRepository(1);
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {

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
            if (cmbRep.SelectedIndex != 0)
                await LoadPlayers();
        }
        private async void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            await settings.SaveSettingsAsync();
            await LoadTeams();
        }

        private async void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new();
            var response = settingsForm.ShowDialog();
            if (response == DialogResult.OK)
            {
                await LoadTeams();
            }
        }
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
