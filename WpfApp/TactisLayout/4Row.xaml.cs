using FootballData.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfGui;

namespace WpfApp.TactisLayout
{
    /// <summary>
    /// Interaction logic for _4Row.xaml
    /// </summary>
    public partial class _4Row : UserControl, IPlayerRow
    {
        public _4Row()
        {
            InitializeComponent();
        }

        public void SetPlayers(IEnumerable<Player> players)
        {
            var penum = players.GetEnumerator();
            do
            {
                var item = LogicalChildren.Current;
                if (item is null) continue;
                if (item is PlayerProfile profile)
                {
                    profile.SetPlayer(penum.Current);
                    penum.MoveNext();
                }
            }
            while (this.LogicalChildren.MoveNext());
        }
    }
}
