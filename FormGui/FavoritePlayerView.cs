﻿using FootballData.Api;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System.Data;

namespace FormGui
{
    public partial class FavoritePlayerView : UserControl
    {
        public FavoritePlayerView()
        {
            InitializeComponent();
            repo = FootballRepositoryFactory.GetRepository(1);
        }

        private List<PlayerLabel> selectedLabels = new List<PlayerLabel>();
        private bool _loading = false;
        private bool clear = false;
        public string? team;
        public IFootballRepository repo;

        public async Task SetTeam(string team)
        {
            if (this.team == team) return;
            this.team = team;
            await LoadPlayers();
        }
        public async Task<List<string>> GetFavortePlayers()
        {
            throw new NotImplementedException();
        }

        private async Task LoadPlayers()
        {
            pnlIgraci.Controls.Clear();
            pnlFavorite.Controls.Clear();
            selectedLabels.Clear();
            pnlFavorite.AllowDrop = true;
            pnlIgraci.AllowDrop = true;
            pnlFavorite.DragEnter += (obj, ev) =>
            {
                foreach (PlayerLabel HoldingLabel in selectedLabels)
                {
                    if (HoldingLabel == null || pnlFavorite.Controls.Contains(HoldingLabel)) return;
                    ev.Effect = DragDropEffects.Move;
                }
            };
            pnlIgraci.DragEnter += (obj, ev) =>
            {
                foreach (PlayerLabel HoldingLabel in selectedLabels)
                {
                    if (HoldingLabel == null || pnlIgraci.Controls.Contains(HoldingLabel)) return;
                    ev.Effect = DragDropEffects.Move;
                }
            };

            pnlIgraci.DragDrop += (obj, ev) =>
            {
                foreach (PlayerLabel HoldingLabel in selectedLabels)
                {
                    pnlFavorite.Controls.Remove(HoldingLabel);
                    pnlIgraci.Controls.Add(HoldingLabel);
                    HoldingLabel.BorderStyle = BorderStyle.None;
                    HoldingLabel.setFavorite(false);
                }
                clear = true;
            };

            pnlFavorite.DragDrop += (obj, ev) =>
            {
                foreach (PlayerLabel HoldingLabel in selectedLabels)
                {
                    pnlIgraci.Controls.Remove(HoldingLabel);
                    pnlFavorite.Controls.Add(HoldingLabel);
                    HoldingLabel.BorderStyle = BorderStyle.None;
                    HoldingLabel.setFavorite(true);
                }
                clear = true;
            };
            var pleyers = await getPlayers();
            List<PlayerLabel> list = new List<PlayerLabel>();
            if (pleyers == null) return;
            foreach (var player in pleyers)
            {
                PlayerLabel item = new PlayerLabel(player.Name, player.ShirtNumber, player.Captain);

                item.MouseDown += (obj, ev) =>
                {
                    var selected = (PlayerLabel)obj;
                    if (selectedLabels.Contains(selected))
                    {
                        foreach (PlayerLabel label in selectedLabels)
                        {
                            label.DoDragDrop(label, DragDropEffects.Move);
                        }
                        if (clear)
                        {
                            clear = false;
                            selectedLabels.Clear();
                        }
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

            IList<PlayerLabel> list = selectedLabels;
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
            IList<PlayerLabel> list = selectedLabels;
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
