using FootballData.Data.Models;

namespace FootballData.Data;

public class LocalRepository : IFootballRepository
{
    public IEnumerable<Match> getMathes() => throw new NotImplementedException();

    public IEnumerable<GroupResult> getGroupResults() => throw new NotImplementedException();

    public IEnumerable<Result> getResults() => throw new NotImplementedException();

    public IEnumerable<Team> getTeams() => throw new NotImplementedException();
}