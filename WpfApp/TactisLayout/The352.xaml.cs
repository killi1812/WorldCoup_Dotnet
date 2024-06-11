using FootballData.Data.Models;
using System.Collections;
using System.Windows.Controls;

namespace WpfApp.TactisLayout
{
    /// <summary>
    /// Interaction logic for The352.xaml
    /// </summary>
    public partial class The352 : UserControl, IPlayerPostava
    {
        public The352()
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
