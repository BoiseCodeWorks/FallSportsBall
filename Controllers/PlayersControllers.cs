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
    public class PlayersController : ControllerBase
    {
        private readonly PlayersService _ps;
        public PlayersController(PlayersService ps)
        {
            _ps = ps;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            try
            {
                return Ok(_ps.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            try
            {
                return Ok(_ps.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult<Player> Create([FromBody]Player newPlayer)
        {
            try
            {
                return Ok(_ps.Create(newPlayer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Player> Edit([FromBody] Player editPlayer, int id)
        {
            try
            {
                editPlayer.Id = id;
                return Ok(_ps.Edit(editPlayer));
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
                return Ok(_ps.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
