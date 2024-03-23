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
        public event EventHandler<EventArgs> fetchData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO save to txt dat
        }

        private void MainForm_Show(object sender, EventArgs e)
        {

            Settings settings = Settings.GetSettings();
            if (settings.IsNew)
            {
                SettingsForm settingsForm = new();
                settingsForm.ShowDialog();
            }

            //TODO ovo je za nista
            pnlDragOmiljeniIgraci.AllowDrop = true;

        }

        private void Igrac_Click(object sender, EventArgs e)
        {
            //TODO detali igraca
            throw new NotImplementedException();
        }
        //TODO ovo je nesto neznam kj radi
        private void Igrac_MouseDown(object sender, MouseEventArgs e)
        {
            _holdButton = (Button)sender;
            pnlDragIgraci.Controls.Remove(_holdButton);

            pnlDragOmiljeniIgraci.DragDrop += (obj, e) =>
            {
                pnlDragOmiljeniIgraci.Controls.Add(_holdButton);
            };

            Controls.Add(_holdButton);
            _holdButton.BringToFront();
            _holdButton.MouseMove += (sender, e) =>
            {
                var point = PointToClient(MousePosition);
                point.X -= _holdButton.Width / 2;
                point.Y -= _holdButton.Height / 2;
                _holdButton.Location = point;
            };
        }
        private void igrac_MouseUp(object sender, MouseEventArgs e)
        {
            _holdButton = (Button)sender;
            pnlDragIgraci.Controls.Remove(_holdButton);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fetchData += fetchTeams;
            fetchData.Invoke(this, EventArgs.Empty);
        }

        private async void fetchTeams(object sender, EventArgs e)
        {
            cmbRep.Items.Clear();
            Settings settings = Settings.GetSettings();
            repo = FootballRepositoryFactory.GetRepository(settings.Values.Repository);
            IEnumerable<string> teamCodes = (await repo.GetTeams()).Select(t => t.FifaCode).Order();
            cmbRep.Items.AddRange(teamCodes.ToArray());
        }

        private async void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fetchData.Invoke(this, EventArgs.Empty);
            Settings settings = Settings.GetSettings();
            await settings.SaveSettingsAsync();
        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new();
            var response = settingsForm.ShowDialog();
            if (response == DialogResult.OK)
            {
                fetchData.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
