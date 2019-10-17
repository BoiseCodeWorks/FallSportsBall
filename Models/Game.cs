using CanadianSportsball.Interfaces;

namespace CanadianSportsball.Models
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}