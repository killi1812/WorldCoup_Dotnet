using FootballData.Api;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FormGui
{
    //TODO ovo ostavlja zombije jao
    public partial class MainForm : Form
    {
        private Button _holdButton;
        private IFootballRepository repo;
        private bool _loading = false;
        public IEnumerable<string> teams { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Form f = new Form1();
            f.Show();
        }

        private void MainForm_Show(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            if (settings.IsNew)
            {
                SettingsForm settingsForm = new();
                settingsForm.ShowDialog();
            }

        }

        //TODO ovo je nesto neznam kj radi };
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadTeams();
            if (cmbRep.SelectedIndex != 0)
                await LoadPlayers();
        }

        private async Task LoadPlayers()
        {

            //pnlIgraci.Controls.Clear();
            var players = await getPlayers();
            if (players == null)
            {
                return;
            }
            List<Label> list = new List<Label>();
            foreach (var player in players)
            {
                Label lbl = new()
                {
                    Text = player.Name,
                    Tag = player,
                    AutoSize = true,
                };
                list.Add(lbl);
                //button.Click += PlayerButton_Click;
            }
            //pnlIgraci. .Controls.AddRange(labels.ToArray());

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
            _loading = true;
            try
            {
                cmbRep.Items.Clear();
                Settings settings = Settings.GetSettings();
                repo = FootballRepositoryFactory.GetRepository(settings.Values.Repository);
                return (await repo.GetTeams()).Select(t => t.FifaCode).Order();
            }
            catch (Exception err)
            {

                using Form form = new Error(err.Message);
                form.ShowDialog();
            }
            finally
            {
                _loading = false;
            }
            return null;
        }

        private async Task<IOrderedEnumerable<Player>> getPlayers()
        {
            if (cmbRep.SelectedItem == null)
            {
                return null;
            }

            IEnumerable<Match> matches = await repo.GetMatchesByCountry(cmbRep.SelectedItem.ToString());
            IOrderedEnumerable<Player> players = matches
                .Where(m => m.HomeTeamResult.FifaCode == cmbRep.SelectedItem.ToString())
                .Select(m => m.HomeTeamStatistics)
                .SelectMany(s => s.StartingEleven.Concat(s.Substitutes))
                .Union(
                    matches.Where(m => m.AwayTeamResult.FifaCode == cmbRep.SelectedItem.ToString())
                    .Select(m => m.AwayTeamStatistics)
                    .SelectMany(s => s.StartingEleven.Concat(s.Substitutes))
                    )
                .DistinctBy(p => p.ShirtNumber)
                .OrderBy(p => p.Name);
            return players;

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

        private void cmbRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            string teamCode = cmbRep.SelectedItem.ToString();
            settings.Values.FavoritTimeFifaCode = teamCode;
            LoadPlayers();
        }
    }
}
