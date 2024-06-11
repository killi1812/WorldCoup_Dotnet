using FootballData.Data.Models;
using System;
using System.Collections;
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

namespace WpfApp.TactisLayout
{
    /// <summary>
    /// Interaction logic for The433.xaml
    /// </summary>
    public partial class The433 : UserControl, IPlayerPostava
    {
        public The433()
        {
            InitializeComponent();
        }
        public void SetPlayers(IEnumerable<Player> players, bool home)
        {
            if (home)
            {
                IPlayerPostava.Flip(field);
            }

            IEnumerator item = field.Children.GetEnumerator();
            IPlayerPostava.SetPlayerProfiles(players, item);
        }

    }
}
