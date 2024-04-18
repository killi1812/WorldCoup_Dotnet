using FootballData.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGui
{
    public partial class Form1 
    {
        public async void ShowRangList()
        {
            var players = await getPlayers();
            List<Label> list = new List<Label>();
            foreach (Player player in players)
            {
                Label lblPlayer = new Label
                {
                    Text = $"{player.Name} {player.ShirtNumber}"
                };
            }
            panelPlayersRank.Controls.AddRange(list.ToArray());
        }
    }
}
