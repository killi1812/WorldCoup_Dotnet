using FootballData.Api;
using FootballData.Data.Models;

namespace FootballData.Data;

public class CloudRepository : IFootballRepository
{
    public Task<IEnumerable<Match>> GetMatches() => throw new NotImplementedException();

    public Task<IEnumerable<GroupResult>> GetGroupResults() => throw new NotImplementedException();

    public Task<IEnumerable<Result>> GetResults() => throw new NotImplementedException();

    public Task<IEnumerable<Team>> GetTeams() => throw new NotImplementedException();
}