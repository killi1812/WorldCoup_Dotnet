using System.Collections;
using FootballData.Data.Models;

namespace FootballData.Data;

public interface IFootballRepository
{
    IEnumerable<Match> getMathes();
    IEnumerable<GroupResult> getGroupResults();
    IEnumerable<Result> getResults();
    IEnumerable<Team> getTeams();
}