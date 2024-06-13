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

namespace WpfGui
{
    /// <summary>
    /// Interaction logic for PlayerProfile.xaml
    /// </summary>
    public partial class PlayerProfile : UserControl
    {
        public PlayerProfile(Player player)
        {
            InitializeComponent();
            SetPlayer(player);
        }
        public PlayerProfile()
        {
            InitializeComponent();
        }
        public Player Player { get; set; }
        public void SetPlayer(Player player)
        {
            this.Player = player;
            lblNumber.Content = Player.ShirtNumber;
            lblTooltip.Content = Player.Name; 
        }

        private void StackPanel_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO add opening for preveiw send player
        }
    }
}
