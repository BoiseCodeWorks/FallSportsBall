namespace CanadianSportsball.Interfaces
{
    public interface IGame
    {
        int WinnerId { get; set; }
        int HomeTeamId { get; set; }
        int AwayTeamId { get; set; }

    }
}