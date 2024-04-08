﻿using FootballData.Api;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            repo = FootballRepositoryFactory.GetRepository(1);
        }
        private IFootballRepository repo;
        private List<Label> selectedLabels = new List<Label>();
        private bool _loading = false;
        public IEnumerable<string> teams { get; set; }

        private async void LoadPlayers()
        {
            var pleyers = await getPlayers();
            List<Label> list = new List<Label>();
            foreach (var player in pleyers)
            {
                Label item = new Label
                {
                    Text = player.Name,
                };
                item.Click += (obj, ev) =>
                {
                    var selected = (Label)obj;
                    if (selectedLabels.Contains(selected))
                    {
                        selected.BorderStyle = BorderStyle.None;
                        selectedLabels.Remove(selected);

                    }
                    else
                    {
                        selected.BorderStyle = BorderStyle.Fixed3D;
                        selectedLabels.Add(selected);
                    }
                };
                list.Add(item);
            }
            pnlIgraci.Controls.AddRange(list.ToArray());
        }

        private void btnAllRight_Click(object sender, EventArgs e)
        {
            if (pnlIgraci.Controls.Count != 0)
            {
                Control[] arr = new Control[pnlIgraci.Controls.Count];
                pnlIgraci.Controls.CopyTo(arr, 0);
                pnlFavorite.Controls.AddRange(arr);
            }
        }

        private void BtnAllLeft_Click(object sender, EventArgs e)
        {
            if (pnlFavorite.Controls.Count != 0)
            {
                Control[] arr = new Control[pnlFavorite.Controls.Count];
                pnlFavorite.Controls.CopyTo(arr, 0);
                pnlIgraci.Controls.AddRange(arr);
            }

        }

        private void btnSelectedRight_Click(object sender, EventArgs e)
        {

            IList list = selectedLabels;
            for (int i = 0; i < list.Count; i++)
            {
                Control c = (Control)list[i];
                if (!pnlFavorite.Controls.Contains(c))
                {
                    pnlFavorite.Controls.Add(c);
                }
            }
        }

        private void btnOneLeft_Click(object sender, EventArgs e)
        {
            IList list = selectedLabels;
            for (int i = 0; i < list.Count; i++)
            {
                Control c = (Control)list[i];
                if (!pnlIgraci.Controls.Contains(c))
                {
                    pnlIgraci.Controls.Add(c);
                }
            }
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

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadTeams();
            if (cmbRep.SelectedIndex != 0)
                LoadPlayers();
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
