namespace CanadianSportsball.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        int Id { get; set; }
        int TeamId { get; set; }
    }
}