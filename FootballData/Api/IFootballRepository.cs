using FootballData.Data.Models;

namespace FootballData.Api;

public interface IFootballRepository
{
    Task<IEnumerable<Match>> GetMatches();
    Task<IEnumerable<GroupResult>> GetGroupResults();
    Task<IEnumerable<Result>> GetResults();
    Task<IEnumerable<Team>> GetTeams();
}