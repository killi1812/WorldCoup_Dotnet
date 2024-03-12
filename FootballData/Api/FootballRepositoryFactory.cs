namespace FootballData.Data;

public static class FootballRepositoryFactory
{
    public static IFootballRepository GetRepository(int option = 0)
    {
        return option switch
        {
            0 => new LocalRepository(),
            1 => new CloudRepository(),
            _ => throw new InvalidRepositoryException(option.ToString())
        };
    }
}
public class InvalidRepositoryException : Exception
{
    public InvalidRepositoryException(string message) : base(message)
    {
    }
}