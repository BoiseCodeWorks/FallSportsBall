using System;
using CanadianSportsball.Models;

namespace CanadianSportsball.Services
{
    public class TeamsService
    {
        private readonly TeamsRepository _repo;

        public TeamsService(TeamsRepository repo)
        {
            _repo = repo;
        }
        internal object Get()
        {
            throw new NotImplementedException();
        }

        internal object Get(int id)
        {
            throw new NotImplementedException();
        }

        internal object Create(Team newTeam)
        {
            throw new NotImplementedException();
        }

        internal object Edit(Team editTeam)
        {
            throw new NotImplementedException();
        }

        internal object Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}