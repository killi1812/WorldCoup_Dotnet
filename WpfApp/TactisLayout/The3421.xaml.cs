using FootballData.Data.Models;
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
            var penum = players.GetEnumerator();
            var item = field.Children.GetEnumerator();
            var profiles = new List<PlayerProfile>();
            while (item.MoveNext())
            {
                if (item.Current is PlayerProfile profile)
                    profiles.Add(profile);
                if (item.Current is Grid grid)
                    profiles.AddRange(grid.Children.OfType<PlayerProfile>());
            }

            if (profiles.Count > 11) throw new Exception("Kako ima vise od 11 igraca");
            if(home) profiles.Reverse();
            var profilEnum = profiles.GetEnumerator();
            while (penum.MoveNext())
            {
                if (profilEnum.MoveNext())
                {
                    profilEnum.Current.SetPlayer(penum.Current);
                }
            }
        }
    }
}
