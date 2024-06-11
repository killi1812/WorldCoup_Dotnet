using FootballData.Data.Models;
using System.Collections;
using System.Windows.Controls;

namespace WpfApp.TactisLayout
{
    /// <summary>
    /// Interaction logic for The532.xaml
    /// </summary>
    public partial class The532 : UserControl, IPlayerPostava
    {
        public The532()
        {
            InitializeComponent();
        }
        public void SetPlayers(IEnumerable<Player> players, bool home)
        {
            if (home)
                IPlayerPostava.Flip(field);

            IEnumerator item = field.Children.GetEnumerator();
            IPlayerPostava.SetPlayerProfiles(players, item);
        }
    }
}
