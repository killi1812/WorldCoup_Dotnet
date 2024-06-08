using FootballData.Api;
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

namespace WpfGui
{
    /// <summary>
    /// Interaction logic for PostavaView.xaml
    /// </summary>
    public partial class PostavaView : UserControl
    {
        public PostavaView()
        {
            InitializeComponent();
        }
        private Match match;
        public void SetMatch(Match m)
        {
            match = m;
        }

        private void SetPlayers()
        {
            var pozitions = match.AwayTeamStatistics.Tactics;

        }
    }
}
