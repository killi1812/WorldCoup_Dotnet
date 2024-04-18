using FootballData.Api;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System.Collections;

namespace FormGui
{
    public partial class Form1 : Form
    {
        private List<Label> selectedLabels = new List<Label>();
        private Label? HoldingLabel = null;
        private bool _loading = false;

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


       

        private async void cmbRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.GetSettings();
            string teamCode = cmbRep.SelectedItem.ToString();
            settings.Values.FavoritTimeFifaCode = teamCode;
            await LoadPlayers();
        }
    }
}

