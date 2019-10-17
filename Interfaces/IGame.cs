namespace CanadianSportsball.Interfaces
{
    public interface IGame
    {
        int Id { get; set; }
        int WinnerId { get; set; }
        int HomeTeamId { get; set; }
        int AwayTeamId { get; set; }

    }
}