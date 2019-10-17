using System;
using System.Collections.Generic;
using System.Data;
using CanadianSportsball.Models;
using Dapper;

namespace CanadianSportsball.Repositories
{
    public class TeamsRepository
    {
        private readonly IDbConnection _db;
        public TeamsRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Team> Get()
        {
            string sql = "SELECT * FROM teams";
            return _db.Query<Team>(sql);
        }

        public Team Get(int id)
        {
            string sql = "SELECT * FROM teams WHERE id = @id";
            return _db.QueryFirstOrDefault<Team>(sql, new { id });
        }

        public Team Get(string name)
        {
            string sql = "SELECT * FROM teams WHERE name = @name";
            return _db.QueryFirstOrDefault<Team>(sql, new { name });
        }

        public int Create(Team newTeam)
        {
            string sql = @"
                INSERT INTO teams
                (name, mascot)
                VALUES
                (@Name,@Mascot);
                SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newTeam);
        }

        public void Edit(Team team)
        {
            string sql = @"
                UPDATE teams
                SET
                    name = @Name,
                    mascot = @Mascot
                WHERE id = @Id";
            _db.Execute(sql, team);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM teams WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}