using FootballData.Data.Models;
using FootballData.ProjectSettings;
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
using WpfApp;

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
            setImg();
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
            setImg();
        }
        private void setImg()
        {
            string path = AppRepo.GetImagePath(Player.Name);
            if (path == null) return;
            imgPlayer.Source = new BitmapImage(new Uri(path));
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var pp = new PlayerPreview(Player);
            pp.ShowDialog();

        }
    }
}
