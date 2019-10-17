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
    public class TeamsController : ControllerBase
    {
        private readonly TeamsService _ts;
        public TeamsController(TeamsService ts)
        {
            _ts = ts;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
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
        public ActionResult<Team> Get(int id)
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
        public ActionResult<Team> Create([FromBody]Team newTeam)
        {
            try
            {
                return Ok(_ts.Create(newTeam));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Team> Edit([FromBody] Team editTeam, int id)
        {
            try
            {
                editTeam.Id = id;
                return Ok(_ts.Edit(editTeam));
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