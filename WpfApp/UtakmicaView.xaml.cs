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

namespace WpfGui;



/// <summary>
/// Interaction logic for UtakmicaView.xaml
/// </summary>
public partial class UtakmicaView : UserControl
{
    public UtakmicaView()
    {
        InitializeComponent();
        api = FootballRepositoryFactory.GetRepository(Settings.GetSettings().Values.Repository);
        //api = FootballRepositoryFactory.GetRepository(1);
        LoadTeams();
    }

    private async void LoadTeams()
    {
        teams = await api.GetTeams();

        cmbFavorite.ItemsSource = teams.Select(t => t.FifaCode);
    }

    private void LoadFavoriteTeam()
    {
        throw new NotImplementedException();
    }

    private IFootballRepository api;
    private string favoriteTeam;
    private string OpponendTeam;
    private IEnumerable<Team> teams;
    private void cmbFavorite_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox)
        {
            string team = (string)comboBox.SelectedValue;
            switch (comboBox.Name)
            {
                case "cmbFavorite":
                    favoriteTeam = team;
                    LoadStats(0);
                    break;
                case "cmbOpponed":
                    OpponendTeam = team;
                    LoadStats(1);
                    break;
            }
        }
    }

    private async void LoadStats(int option = 0)
    {
        string team = "";
        switch (option)
        {
            case 0:
                team = (string)cmbFavorite.SelectedValue;
                break;
            case 1:
                team = (string)cmbOpponed.SelectedValue;
                break;
        }
        if (team == null) return;
        var matches = await api.GetMatchesByCountry(team);

        if (option == 0)
        {
            var homeList = matches.Where(m => m.HomeTeamResult.FifaCode != team).Select(m => m.HomeTeamResult.FifaCode).ToList();
            var awayList = matches.Where(m => m.AwayTeamResult.FifaCode != team).Select(m => m.AwayTeamResult.FifaCode).ToList();
            cmbOpponed.ItemsSource = homeList.Union(awayList);
        }

        var s = SetResults(matches, team);
        switch (option)
        {
            case 0:
                tbFavoriteResults.Text = s.ToString();
                break;
            case 1:
                tbResults.Text = s.ToString();
                break;
        }

        if (AreBothSelected())
        {
            StringBuilder sb = new StringBuilder();
            //TODO find rezultat

            var result =  
            getMatchBetween(matches, (string)cmbFavorite.SelectedValue, (string)cmbOpponed.SelectedValue);

            lblResult.Content = $"Result {result.Item1} : {result.Item2}";
        }

    }

    private (int, int) getMatchBetween(IEnumerable<Match> matches, string selectedValue1, string selectedValue2)
    {
        var HomeMatch = matches.Where(m => m.AwayTeamResult.FifaCode == selectedValue1 && m.HomeTeamResult.FifaCode == selectedValue2).FirstOrDefault();
        var AwayMatch = matches.Where(m => m.HomeTeamResult.FifaCode == selectedValue1 && m.AwayTeamResult.FifaCode == selectedValue2).FirstOrDefault();
        if (HomeMatch != null)
            return (HomeMatch.AwayTeamResult.Goals,HomeMatch.HomeTeamResult.Goals) ;
        return (AwayMatch.HomeTeamResult.Goals, AwayMatch.AwayTeamResult.Goals);
    }

    private bool AreBothSelected()
    {
        return !(String.IsNullOrEmpty((string)cmbFavorite.SelectedValue) || String.IsNullOrEmpty((string)cmbOpponed.SelectedValue));
    }

    private Stats SetResults(IEnumerable<Match> matches, string team)
    {
        Stats s = new Stats();
        //broj odigranih / pobjeda / poraza / neodlučenih, golova zabijenih/ primljenih / razlika.
        s.Utakmice = matches.Count();
        s.Pobjeda = matches.Count(m => m.WinnerFifaCode == team);
        s.Poraza = matches.Count(m => m.WinnerFifaCode != team);

        //TODO Neznam di naceti neodluceno
        s.Neodluceno = matches.Count(m => m.WinnerFifaCode != team);

        var nameHome = matches.Where(m => m.HomeTeamResult.FifaCode == team).Select(m => m.HomeTeamResult.Country).FirstOrDefault();
        var nameAway = matches.Where(m => m.AwayTeamResult.FifaCode == team).Select(m => m.AwayTeamResult.Country).FirstOrDefault();
        string name = nameHome;
        if (name != null)
        {
            name = nameAway;
        }


        s.Golovi = matches.Where(m => m.HomeTeamCountry == name).Sum(m => m.HomeTeamResult.Goals) + matches.Where(m => m.AwayTeamCountry == name).Sum(m => m.AwayTeamResult.Goals);
        s.Primljeno = matches.Where(m => m.HomeTeamCountry != name).Sum(m => m.HomeTeamResult.Goals) + matches.Where(m => m.AwayTeamCountry != name).Sum(m => m.AwayTeamResult.Goals);
        return s;
    }
}
public class Stats
{
    public int Utakmice { get; set; }
    public int Pobjeda { get; set; }
    public int Poraza { get; set; }
    public int Neodluceno { get; set; }
    public int Golovi { get; set; }
    public int Primljeno { get; set; }

    public override string ToString()
    {
        bool lang = Settings.GetSettings().Values.Language == "en";
        if (lang)
            return $"Matches played: \t{Utakmice}\nWins: \t\t{Pobjeda}\nLoses: \t\t{Poraza}\nTies: \t\t{Neodluceno}\nGoals: \t\t{Golovi}\nGoals taken: \t{Primljeno}\nDifference: \t{Golovi - Primljeno}\n";
        //TODO translate
        return $"Matches played: \t{Utakmice}\nWins: \t{Pobjeda}\nLoses: \t{Poraza}\nTies: \t{Neodluceno}\nGoals: \t{Golovi}\nGoals taken: \t{Primljeno}\nDifference: \t{Golovi - Primljeno}\n";
    }
}
