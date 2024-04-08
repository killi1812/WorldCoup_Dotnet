using FootballData.Api;
using FootballData.Data.Models;
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

        private async void Form1_Load(object sender, EventArgs e)
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
        private async Task<IOrderedEnumerable<Player>> getPlayers()
        {
            IEnumerable<Match> matches = await repo.GetMatchesByCountry("CRO");
            IOrderedEnumerable<Player> players = matches
                .Where(m => m.HomeTeamResult.FifaCode == "CRO")
                .Select(m => m.HomeTeamStatistics)
                .SelectMany(s => s.StartingEleven.Concat(s.Substitutes))
                .Union(
                    matches.Where(m => m.AwayTeamResult.FifaCode == "CRO")
                    .Select(m => m.AwayTeamStatistics)
                    .SelectMany(s => s.StartingEleven.Concat(s.Substitutes))
                    )
                .DistinctBy(p => p.ShirtNumber)
                .OrderBy(p => p.Name);
            return players;

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
    }
}
