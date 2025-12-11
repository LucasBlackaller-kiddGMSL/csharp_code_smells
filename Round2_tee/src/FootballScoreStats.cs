namespace Round2_tee;

public class FootballScoreStats
{
    private IGameData _footballData;

    public FootballScoreStats()
    {
        _footballData = new FootballData();
    }

    public int TeamTotal(string teamName)
    {
        int total = 0;
        Game[] played = _footballData.GetAllPlayed();
        foreach (var game in played)
        {
            total = game.GetTeamScore(teamName, total);
        }
        return total;
    }
}