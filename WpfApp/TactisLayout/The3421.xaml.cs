using FootballData.Data.Models;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfGui;

namespace WpfApp.TactisLayout
{
    /// <summary>
    /// Interaction logic for The3421.xaml
    /// </summary>
    public partial class The3421 : UserControl, IPlayerPostava
    {
        public The3421()
        {
            InitializeComponent();
        }
        public void SetPlayers(IEnumerable<Player> players, bool home)
        {
            IEnumerator item = field.Children.GetEnumerator();
            IPlayerPostava.SetPlayerProfiles(players, home, item);
        }
    }
}
