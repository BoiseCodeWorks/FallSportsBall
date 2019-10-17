using System;
using System.Data;
using CanadianSportsball.Models;

namespace CanadianSportsball.Repositories
{
    public class TeamsRepository
    {
        private readonly IDbConnection _db;
        public TeamsRepository(IDbConnection db)
        {
            _db = db;
        }
        public object Get()
        {
            throw new NotImplementedException();
        }

        public Team Get(int id)
        {
            throw new NotImplementedException();
        }

        public Team Get(string name)
        {
            throw new NotImplementedException();
        }

        public int Create(Team newTeam)
        {
            throw new NotImplementedException();
        }

        public void Edit(Team team)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}