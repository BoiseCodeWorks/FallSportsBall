using CanadianSportsball.Interfaces;

namespace CanadianSportsball.Models
{
    public class Team : ITeam
    {
        public string Name { get; set; }
        public string Mascot { get; set; }
        public int Id { get; set; }


    }
}