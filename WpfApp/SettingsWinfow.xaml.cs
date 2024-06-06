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
using System.Windows.Shapes;

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
        }
        private void loadSettings(object sender)
        {
            Settings settings = Settings.GetSettings();
            
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton button)
            {
                Settings settings = Settings.GetSettings();
                string s = (string)button.Content;
                settings.Values.Language = s;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings s = Settings.GetSettings();
            await s.SaveSettingsAsync();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
