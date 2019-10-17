using System;
using System.Collections.Generic;
using CanadianSportsball.Models;
using CanadianSportsball.Repositories;

namespace CanadianSportsball.Services
{
    public class GamesService
    {
        private readonly GamesRepository _repo;

        public GamesService(GamesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Game> Get()
        {
            return _repo.Get();
        }

        public Game Get(int id)
        {
            Game exists = _repo.Get(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        public Game Create(Game newGame)
        {
            int id = _repo.Create(newGame);
            newGame.Id = id;
            return newGame;
        }

        public Game Edit(Game editGame)
        {
            Game game = _repo.Get(editGame.Id);
            if (game == null) { throw new Exception("Invalid Id"); }
            game.AwayTeamId = editGame.AwayTeamId;
            game.HomeTeamId = editGame.HomeTeamId;
            game.WinnerId = editGame.WinnerId;
            _repo.Edit(game);
            return game;
        }

        public string Delete(int id)
        {
            Game exists = _repo.Get(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id);
            return " that games been iced, eh";
        }
    }
}