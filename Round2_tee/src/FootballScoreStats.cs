namespace Round2_tee;

public class FootballScoreStats
{
    public int TeamTotal(string teamName)
    {
        int total = 0;
        Game[] played = new FootballData().GetAllPlayed();
        foreach (var game in played)
        {
            total = GetTeamScore(teamName, game, total);
        }
        return total;
    }

    private int GetTeamScore(string teamName, Game game, int total)
    {
        if (game.HomeTeam.Equals(teamName))
        {
            total += game.HomeTeamScore;
        }

        if (game.AwayTeam.Equals(teamName))
        {
            total += game.AwayTeamScore;
        }

        return total;
    }
}