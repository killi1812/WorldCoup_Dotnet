using FootballData.Api;
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
    public partial class FavoritePlayerView : UserControl
    {
        public FavoritePlayerView()
        {
            InitializeComponent();
            repo = FootballRepositoryFactory.GetRepository(1);
        }

        private List<Label> selectedLabels = new List<Label>();
        private Label? HoldingLabel = null;
        private bool _loading = false;
        public string? team;
        public IFootballRepository repo;

        public async Task SetTeam(string team)
        {
            if (this.team == team) return;
            this.team = team;
            await LoadPlayers();
        }

        private async Task LoadPlayers()
        {
            pnlIgraci.Controls.Clear();
            pnlFavorite.Controls.Clear();
            selectedLabels.Clear();
            //drag and drop stuff 
            //TODO napraviti da radi na listi ne samo jednom labelu
            pnlFavorite.AllowDrop = true;
            pnlIgraci.AllowDrop = true;
            pnlFavorite.DragEnter += (obj, ev) =>
            {
                if (HoldingLabel == null || pnlFavorite.Controls.Contains(HoldingLabel)) return;
                ev.Effect = DragDropEffects.Move;
            };
            pnlIgraci.DragEnter += (obj, ev) =>
            {
                if (HoldingLabel == null || pnlIgraci.Controls.Contains(HoldingLabel)) return;
                ev.Effect = DragDropEffects.Move;
            };

            pnlIgraci.DragDrop += (obj, ev) =>
            {
                pnlFavorite.Controls.Remove(HoldingLabel);
                pnlIgraci.Controls.Add(HoldingLabel);
            };

            pnlFavorite.DragDrop += (obj, ev) =>
            {
                pnlIgraci.Controls.Remove(HoldingLabel);
                pnlFavorite.Controls.Add(HoldingLabel);

            };
            var pleyers = await getPlayers();
            //TODO dodati zvijezdice
            List<Label> list = new List<Label>();
            if (pleyers == null) return;
            foreach (var player in pleyers)
            {
                Label item = new Label
                {
                    Text = player.Name,
                };

                item.Click += (obj, ev) =>
                {
                    //TODO select is not currently working
                    if (selectedLabels.Count > 0)
                    {
                        foreach (Label label in selectedLabels)
                        {
                            label.DoDragDrop(label, DragDropEffects.Move);
                        }
                    }
                };
                item.MouseDown += (obj, ev) =>
                {

                    var selected = (Label)obj;
                    if (selectedLabels.Contains(selected))
                    {
                        selected.BorderStyle = BorderStyle.None;
                        selectedLabels.Remove(selected);

                    }
                    else
                    {
                        selected.BorderStyle = BorderStyle.FixedSingle;
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

        private async Task<IOrderedEnumerable<Player>> getPlayers()
        {
            if (team == null || team == "")
            {
                return null;
            }

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
            return players;

        }

        private async void cmbRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            string teamCode = team;
            settings.Values.FavoritTimeFifaCode = teamCode;
            await LoadPlayers();
        }

    }
}
