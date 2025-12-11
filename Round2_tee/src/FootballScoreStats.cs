namespace Round2_tee;

public class FootballScoreStats
{
    public int TeamTotal(string teamName)
    {
        int total = 0;
        Game[] played = new FootballData().GetAllPlayed();
        foreach (var game in played)
        {
            total = game.GetTeamScore(teamName, total);
        }
        return total;
    }
}