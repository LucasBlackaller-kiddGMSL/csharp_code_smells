namespace Round2_tee.tests;

public class FootballScoreStatsTests 
{
    [Test]
    public void TotalsFootballScoresForTeam()
    {
        FootballScoreStats stats = new FootballScoreStats(new FootballData());
        Assert.That(stats.TeamTotal("Liverpool"), Is.EqualTo(6));
    }
}