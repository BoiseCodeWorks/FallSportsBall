using CanadianSportsball.Interfaces;

namespace CanadianSportsball.Models
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int TeamId { get; set; }
    }
}