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
            int id = _repo.Create(newTeam);
            newTeam.Id = id;
            return newTeam;
        }

        public Team Edit(Team editTeam)
        {
            Team team = _repo.Get(editTeam.Id);
            if (team == null) { throw new Exception("Invalid Id"); }
            team.Name = editTeam.Name;
            team.Mascot = editTeam.Mascot;
        }

        public Team Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}