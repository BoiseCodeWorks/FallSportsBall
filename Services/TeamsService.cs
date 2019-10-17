using System;
using System.Collections.Generic;
using CanadianSportsball.Models;
using CanadianSportsball.Repositories;

namespace CanadianSportsball.Services
{
    public class TeamsService
    {
        private readonly TeamsRepository _repo;

        public TeamsService(TeamsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Team> Get()
        {
            return _repo.Get();
        }

        public Team Get(int id)
        {
            Team exists = _repo.Get(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        public Team Create(Team newTeam)
        {
            Team team = _repo.Get(newTeam.Name);
            if (team != null) { throw new Exception("Team already exists"); }
        }

        public Team Edit(Team editTeam)
        {
            throw new NotImplementedException();

        }

        public Team Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}