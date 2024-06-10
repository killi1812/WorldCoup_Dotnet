using FootballData.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfGui;

namespace WpfApp.TactisLayout
{
    internal interface IPlayerPostava
    {
        public void SetPlayers(IEnumerable<Player> players, bool home);
        public static void SetPlayerProfiles(IEnumerable<Player> players, bool home, IEnumerator item)
        {
            IEnumerator<Player> penum = players.GetEnumerator();
            var profiles = new List<PlayerProfile>();
            while (item.MoveNext())
            {
                if (item.Current is PlayerProfile profile)
                    profiles.Add(profile);
                if (item.Current is Grid grid)
                    profiles.AddRange(grid.Children.OfType<PlayerProfile>());
            }

            if (profiles.Count > 11) throw new Exception("Kako ima vise od 11 igraca");
            if (home)
            {

                //profiles.Reverse();
            }
            var profilEnum = profiles.GetEnumerator();
            while (penum.MoveNext())
            {
                if (profilEnum.MoveNext())
                {
                    profilEnum.Current.SetPlayer(penum.Current);
                }
            }
        }
        public static void Flip(Grid field)
        {
            var children = field.Children.GetEnumerator();
            List<UIElement> items = new();
            while (children.MoveNext())
            {
                items.Add((UIElement)children.Current);
            }
            field.Children.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                Grid.SetColumn(items[i], i);
                field.Children.Add(items[i]);
            }
        }
    }
}
