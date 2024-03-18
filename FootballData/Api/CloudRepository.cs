using FootballData.Data.Models;

namespace FootballData.Data;

public class CloudRepository : IFootballRepository
{
    public Task<IEnumerable<Match>> getMatches() => throw new NotImplementedException();

    public Task<IEnumerable<GroupResult>> getGroupResults() => throw new NotImplementedException();

    public Task<IEnumerable<Result>> getResults() => throw new NotImplementedException();

    public Task<IEnumerable<Team>> getTeams() => throw new NotImplementedException();
}