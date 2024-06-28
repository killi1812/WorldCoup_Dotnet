using FootballData.ProjectSettings;
using System.Windows;
using System.Windows.Controls;

namespace WpfGui
{
    /// <summary>
    /// Interaction logic for SettingsWinfow.xaml
    /// </summary>
    public partial class SettingsWinfow : Window
    {
        public SettingsWinfow()
        {
            InitializeComponent();
            loadSettings();
        }
        private void loadSettings()
        {
            AppRepo settings = AppRepo.GetSettings();

            var lang = grpLang.Children;
            foreach (RadioButton item in lang)
            {
                item.IsChecked = (string)item.Content == settings.Values.Language;
            }

            var gender = grpGender.Children;
            foreach (RadioButton item in gender)
            {
                item.IsChecked = (string)item.Content == settings.Values.LeagueGender;
            }

            var rez = grpRez.Children;
            var rezolution = settings.Values.Rezolucija;
            foreach (RadioButton item in rez)
            {
                item.IsChecked = (string)item.Content == $"{rezolution.Item1}x{rezolution.Item2}";
            }
        }

        private void Lang(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
            {
                AppRepo settings = AppRepo.GetSettings();
                string s = (string)button.Content;
                settings.Values.Language = s;
            }
        }
        private void Gender(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
            {
                AppRepo settings = AppRepo.GetSettings();
                string s = (string)button.Content;
                settings.Values.LeagueGender = s;
            }
        }
        private void Rezolution(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
            {
                AppRepo settings = AppRepo.GetSettings();
                string s = (string)button.Content;
                if (s == "FullScreen")
                {
                    settings.Values.Rezolucija = new Pair<int> (0, 0);
                    return;
                }
                int first, second;
                first = int.Parse(s.Split("x")[0]);
                second = int.Parse(s.Split("x")[1]);
                settings.Values.Rezolucija = new Pair<int>(first, second);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AppRepo s = AppRepo.GetSettings();
            await s.SaveSettingsAsync();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
