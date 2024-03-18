using System.Collections;
using FootballData.Data.Models;

namespace FootballData.Data;

public interface IFootballRepository
{
    Task<IEnumerable<Match>> getMatches();
    Task<IEnumerable<GroupResult>> getGroupResults();
    Task<IEnumerable<Result>> getResults();
    Task<IEnumerable<Team>> getTeams();
}