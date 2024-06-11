using FootballData.Api;
using FootballData.Data.Enums;
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
using WpfApp.TactisLayout;

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
        IPlayerPostava fieldTactics;
        public void SetPlayers(TeamStatistics stats, bool home)
        {
            var pozitions = stats.Tactics;
            SetPlayerTactics(pozitions);
            var players = stats.StartingEleven;
            fieldTactics.SetPlayers(players, home);
        }

        public void SetPlayerTactics(Tactics t)
        {
            //TODO remove
            fieldTactics = new The352();
            switch (t)
            {
                case Tactics.The3421:
                    fieldTactics = new The3421();
                    break;
                case Tactics.The343:
                    fieldTactics = new The343();
                    break;
                case Tactics.The352:
                    fieldTactics = new The352();
                    break;
                case Tactics.The4231:
                    fieldTactics = new The4231();
                    break;
                case Tactics.The4321:
                    fieldTactics = new The4321();
                    break;
                case Tactics.The433:
                    fieldTactics = new The433();
                    break;
                case Tactics.The442:
                    fieldTactics = new The442();
                    break;
                case Tactics.The451:
                    fieldTactics = new The451();
                    break;
                case Tactics.The532:
                    break;
                case Tactics.The541:
                    break;
                default:
                    fieldTactics = new The3421();
                    break;
            }
            if (fieldTactics is UserControl control)
            {
                field.Children.Clear();
                field.Children.Add(control);
                control.Visibility = Visibility.Visible;
            }
        }
    }
}