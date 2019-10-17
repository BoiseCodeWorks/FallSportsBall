using System;
using System.Collections.Generic;
using CanadianSportsball.Models;
using CanadianSportsball.Repositories;

namespace CanadianSportsball.Services
{
    public class PlayersService
    {
        private readonly PlayersRepository _repo;

        public PlayersService(PlayersRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Player> Get()
        {
            return _repo.Get();
        }

        public Player Get(int id)
        {
            Player exists = _repo.Get(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        public Player Create(Player newPlayer)
        {
            int id = _repo.Create(newPlayer);
            newPlayer.Id = id;
            return newPlayer;
        }

        public Player Edit(Player editPlayer)
        {
            Player player = _repo.Get(editPlayer.Id);
            if (player == null) { throw new Exception("Invalid Id"); }
            player.Name = editPlayer.Name;
            player.TeamId = editPlayer.TeamId;
            _repo.Edit(player);
            return player;
        }

        public string Delete(int id)
        {
            Player exists = _repo.Get(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id);
            return " that players been iced, eh";
        }
    }
}