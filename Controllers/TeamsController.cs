using System;
using System.Collections.Generic;
using CanadianSportsball.Models;
using CanadianSportsball.Services;
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

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }














}