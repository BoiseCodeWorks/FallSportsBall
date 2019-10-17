using System.Collections.Generic;
using System.Data;
using CanadianSportsball.Models;
using Dapper;

namespace CanadianSportsball.Repositories
{
    public class PlayersRepository
    {
        private readonly IDbConnection _db;
        public PlayersRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Player> Get()
        {
            string sql = "SELECT * FROM players";
            return _db.Query<Player>(sql);
        }

        public Player Get(int id)
        {
            string sql = "SELECT * FROM players WHERE id = @id";
            return _db.QueryFirstOrDefault<Player>(sql, new { id });
        }

        public Player Get(string name)
        {
            string sql = "SELECT * FROM players WHERE name = @name";
            return _db.QueryFirstOrDefault<Player>(sql, new { name });
        }

        public int Create(Player newPlayer)
        {
            string sql = @"
                INSERT INTO players
                (name, teamId)
                VALUES
                (@Name,@TeamId);
                SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newPlayer);
        }

        public void Edit(Player player)
        {
            string sql = @"
                UPDATE players
                SET
                    name = @Name,
                    teamId = @TeamId
                WHERE id = @Id";
            _db.Execute(sql, player);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM players WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}