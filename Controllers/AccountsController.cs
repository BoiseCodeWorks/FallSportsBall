using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CanadianSportsball.Models;
using CanadianSportsball.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CanadianSportsball.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsService _as;
        public AccountsController(AccountsService acctService)
        {
            _as = acctService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRegistration creds)
        {
            try
            {
                User user = _as.Register(creds);
                user.SetClaims();
                await HttpContext.SignInAsync(user._principal);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] UserLoginCreds creds)
        {
            try
            {
                User user = _as.Login(creds);
                user.SetClaims();
                await HttpContext.SignInAsync(user._principal);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [Authorize] //NOTE this is the same as the route guard
        [HttpDelete("Logout")]
        public async Task<ActionResult<bool>> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Ok(true);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [Authorize]
        [HttpGet("Authenticate")]
        public async Task<ActionResult<User>> Authenticate()
        {
            try
            {
                //NOTE THIS IS HOW YOU GET THE USER ID (node => req.session.uid)
                var n = HttpContext.User.FindFirstValue(ClaimTypes.Name);
                var id = HttpContext.User.FindFirstValue("Id");
                User user = _as.GetUserById(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                await HttpContext.SignOutAsync();
                return Unauthorized(e.Message);
            }
        }
    }
}