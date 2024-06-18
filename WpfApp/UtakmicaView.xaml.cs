using FootballData.Api;
using FootballData.Data.Models;
using FootballData.ProjectSettings;
using System.Text;
using System.Windows.Controls;

namespace WpfGui;



/// <summary>
/// Interaction logic for UtakmicaView.xaml
/// </summary>

/*
     The3421,
    The343,
    The352,
    The4231,
    The4321,
    The433,
    The442,
    The451,
    The532,
    The541
 */
public partial class UtakmicaView : UserControl
{
    public UtakmicaView()
    {
        InitializeComponent();
        //api = FootballRepositoryFactory.GetRepository(AppRepo.GetSettings().Values.Repository);
        api = FootballRepositoryFactory.GetRepository();
        LoadTeams();
    }

    public bool loading = false;
    public async void LoadTeams()
    {
        loading = true;
        try
        {
            teams = await api.GetTeams();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return;
        }
        finally { loading = false; }
        cmbFavorite.ItemsSource = teams.Select(t => t.FifaCode);
        var favTeam = AppRepo.GetSettings().Values.FavoritTimeFifaCode;
        if (String.IsNullOrEmpty(favTeam)) return;
        cmbFavorite.Text = favTeam;
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
            var result = GetResultBetween(matches, (string)cmbFavorite.SelectedValue, (string)cmbOpponed.SelectedValue);
            var matchStats = GetMatchBetween(matches, (string)cmbFavorite.SelectedValue, (string)cmbOpponed.SelectedValue);
            lblResult.Content = $"Result {result.Item1} : {result.Item2}";
            postavaFavorite.SetPlayers(matchStats.Item1, true);
            postavaOpponent.SetPlayers(matchStats.Item2, false);
        }

    }

    private (int, int) GetResultBetween(IEnumerable<Match> matches, string selectedValue1, string selectedValue2)
    {
        var HomeMatch = matches.Where(m => m.AwayTeamResult.FifaCode == selectedValue1 && m.HomeTeamResult.FifaCode == selectedValue2).FirstOrDefault();
        var AwayMatch = matches.Where(m => m.HomeTeamResult.FifaCode == selectedValue1 && m.AwayTeamResult.FifaCode == selectedValue2).FirstOrDefault();
        if (HomeMatch != null)
            return (HomeMatch.AwayTeamResult.Goals, HomeMatch.HomeTeamResult.Goals);
        return (AwayMatch.HomeTeamResult.Goals, AwayMatch.AwayTeamResult.Goals);
    }
    private (TeamStatistics, TeamStatistics) GetMatchBetween(IEnumerable<Match> matches, string selectedValue1, string selectedValue2)
    {
        var HomeMatch = matches.Where(m => m.AwayTeamResult.FifaCode == selectedValue1 && m.HomeTeamResult.FifaCode == selectedValue2).FirstOrDefault();
        var AwayMatch = matches.Where(m => m.HomeTeamResult.FifaCode == selectedValue1 && m.AwayTeamResult.FifaCode == selectedValue2).FirstOrDefault();

        if (HomeMatch != null)
        {
            HomeMatch = CalculatePlayerStats(HomeMatch);
            return (HomeMatch.AwayTeamStatistics, HomeMatch.HomeTeamStatistics);
        }
        AwayMatch = CalculatePlayerStats(AwayMatch);
        return (AwayMatch.HomeTeamStatistics, AwayMatch.AwayTeamStatistics);
    }

    private Match CalculatePlayerStats(Match match)
    {
        var events = match.AwayTeamEvents.Concat(match.HomeTeamEvents);

        var awayPlayers = match.AwayTeamStatistics.StartingEleven.ToList();
        awayPlayers.ForEach(p => p.playerEventsForCurrentGame = events.Where(ev => ev.Player == p.Name).ToList());
        var homePlayers = match.HomeTeamStatistics.StartingEleven.ToList();
        homePlayers.ForEach(p => p.playerEventsForCurrentGame = events.Where(ev => ev.Player == p.Name).ToList());

        match.HomeTeamStatistics.StartingEleven = homePlayers;
        match.AwayTeamStatistics.StartingEleven = awayPlayers;

        return match;
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
        bool lang = AppRepo.GetSettings().Values.Language == "en";
        if (lang)
            return $"Matches played: \t{Utakmice}\nWins: \t\t{Pobjeda}\nLoses: \t\t{Poraza}\nTies: \t\t{Neodluceno}\nGoals: \t\t{Golovi}\nGoals taken: \t{Primljeno}\nDifference: \t{Golovi - Primljeno}\n";
        //TODO translate
        return $"Broj Utakmica: \t{Utakmice}\nPobjeda: \t{Pobjeda}\nPorazi: \t{Poraza}\nIzjednačeno: \t{Neodluceno}\nGolovi: \t{Golovi}\nPrimljeni Golovi: \t{Primljeno}\nRazlika: \t{Golovi - Primljeno}\n";
    }
}
