using FootballData.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.TactisLayout
{
    internal interface IPlayerPostava
    {
        public void SetPlayers(IEnumerable<Player> players, bool home);
    }
}
