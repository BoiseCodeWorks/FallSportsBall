using CanadianSportsball.Interfaces;

namespace CanadianSportsball.Models
{
    public class Game : IGame
    {
        public int WinnerId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}