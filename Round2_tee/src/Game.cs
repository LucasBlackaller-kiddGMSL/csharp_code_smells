namespace Round2_tee;

public class Game
{
    public string HomeTeam { get; }
    public int HomeTeamScore { get; }
    public string AwayTeam { get; }
    public int AwayTeamScore { get; }

    public Game(string homeTeam, int homeTeamScore, string awayTeam, int awayTeamScore)
    {
        HomeTeam = homeTeam;
        HomeTeamScore = homeTeamScore;
        AwayTeam = awayTeam;
        AwayTeamScore = awayTeamScore;
    }

    public int GetTeamScore(string teamName, int total)
    {
        if (this.HomeTeam.Equals(teamName))
        {
            total += this.HomeTeamScore;
        }

        if (this.AwayTeam.Equals(teamName))
        {
            total += this.AwayTeamScore;
        }

        return total;
    }
}