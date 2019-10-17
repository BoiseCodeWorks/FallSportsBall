using System;
using System.Collections.Generic;
using System.Data;
using CanadianSportsball.Models;
using Dapper;

namespace CanadianSportsball.Repositories
{
    public class GamesRepository
    {
        private readonly IDbConnection _db;
        public GamesRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Game> Get()
        {
            string sql = "SELECT * FROM games";
            return _db.Query<Game>(sql);
        }

        public Game Get(int id)
        {
            string sql = "SELECT * FROM games WHERE id = @id";
            return _db.QueryFirstOrDefault<Game>(sql, new { id });
        }

        public Game GetTeamGames(int teamId)
        {
            string sql = "SELECT * FROM games WHERE awayTeamId = @teamId OR homeTeamId = @teamId";
            return _db.QueryFirstOrDefault<Game>(sql, new { teamId });
        }

        public int Create(Game newGame)
        {
            string sql = @"
                INSERT INTO games
                (awayTeamId, homeTeamId)
                VALUES
                (@AwayTeamId, @HomeTeamId);
                SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newGame);
        }

        public IEnumerable<Player> GetGamePlayersByGameId(int id)
        {
            string sql = @"
                SELECT * FROM players p
                JOIN games g
                    ON p.teamId = g.awayTeamId
                    OR p.teamId = g.homeTeamId
                WHERE g.id = @id";
            return _db.Query<Player>(sql, new { id });
        }

        public void Edit(Game game)
        {
            string sql = @"
                UPDATE games
                SET
                    awayTeamId = @AwayTeamId,
                    homeTeamId = @HomeTeamId,
                    winnerId = @WinnerId
                WHERE id = @Id";
            _db.Execute(sql, game);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM games WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}