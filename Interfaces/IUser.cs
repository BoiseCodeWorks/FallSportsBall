namespace CanadianSportsball.Interfaces
{
    public interface IUser
    {
        string Id { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Hash { get; set; }
    }
}