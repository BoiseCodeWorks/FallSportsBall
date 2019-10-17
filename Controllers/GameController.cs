using System;
using System.Collections.Generic;
using CanadianSportsball.Models;
using CanadianSportsball.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CanadianSportsball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _ts;
        public GamesController(GamesService ts)
        {
            _ts = ts;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            try
            {
                return Ok(_ts.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            try
            {
                return Ok(_ts.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/players")]
        public ActionResult<IEnumerable<Player>> GetPlayers(int id)
        {
            try
            {
                return Ok(_ts.GetPlayers(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult<Game> Create([FromBody]Game newGame)
        {
            try
            {
                return Ok(_ts.Create(newGame));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Game> Edit([FromBody] Game editGame, int id)
        {
            try
            {
                editGame.Id = id;
                return Ok(_ts.Edit(editGame));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_ts.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}