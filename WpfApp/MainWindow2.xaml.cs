using FootballData.ProjectSettings;
using System.Windows;
using WpfGui;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
            if (AppRepo.GetSettings().IsNew)
            {
                //TODO open settings
                var settings = new SettingsWinfow();
                settings.ShowDialog();
            }
            var rez = AppRepo.GetSettings().Values.Rezolucija;
            if (rez.Item1 == 0)
            {

                window.WindowState = WindowState.Maximized;
            }
            else
            {
                this.window.Width = rez.Item1;
                this.window.Height = rez.Item2;
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWinfow();
            var result = settingsWindow.ShowDialog();
        }
    }
}