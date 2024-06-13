using FootballData.Data.Enums;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerPreview.xaml
    /// </summary>
    public partial class PlayerPreview : Window
    {
        public PlayerPreview(Player? player)
        {
            InitializeComponent();
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            this.player = player;
            SetText();
            setImg();
        }

        private Player player;
        private void SetText()
        {
            StringBuilder sb = new StringBuilder();
            bool eng = AppRepo.GetSettings().Values.Language == "en";
            if (player.playerEventsForCurrentGame == null) return;
            if (eng)
            {
                sb.AppendLine(player.Name);
                sb.AppendLine(player.Captain ? "Captain" : "");
                sb.AppendLine($"Number: {player.ShirtNumber}");
                sb.AppendLine($"Position: {player.Position.ToString()}");
                sb.AppendLine($"Goals: {player.playerEventsForCurrentGame.Count(e => e.TypeOfEvent == TypeOfEvent.Goal)}");
                sb.AppendLine($"Yellow Cards: {player.playerEventsForCurrentGame.Count(e => e.TypeOfEvent == TypeOfEvent.YellowCard || e.TypeOfEvent == TypeOfEvent.YellowCardSecond)}");
            }
            else
            {
                sb.AppendLine(player.Name);
                sb.AppendLine(player.Captain ? "Kapetan" : "");
                sb.AppendLine($"Broj: {player.ShirtNumber}");
                sb.AppendLine($"Pozicija: {player.Position.ToString()}");
                sb.AppendLine($"Golovi: {player.playerEventsForCurrentGame.Count(e => e.TypeOfEvent == TypeOfEvent.Goal)}");
                sb.AppendLine($"Žuti Kartoni: {player.playerEventsForCurrentGame.Count(e => e.TypeOfEvent == TypeOfEvent.YellowCard || e.TypeOfEvent == TypeOfEvent.YellowCardSecond)}");
            }

            PlayerStats.Text = sb.ToString();
        }
        private void setImg()
        {
            string path = AppRepo.GetImagePath(player.Name);
            if (path == null) return;
            imgPlayer.Source = new BitmapImage(new Uri(path));
        }
    }
}
