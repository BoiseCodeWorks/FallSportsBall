using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using CanadianSportsball.Interfaces;

namespace CanadianSportsball.Models
{
    public class UserRegistration //use for [FromBody] when registering account
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

    public class UserLoginCreds
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }



    public class User : IUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        internal ClaimsPrincipal _principal { get; private set; } //NOTE this is your 'badge' confirming you are logged in (node => session)

        /// <summary>Creates claim and adds to requests (HTTPContext) </summary>
        internal void SetClaims()
        {
            var claims = new List<Claim>
            {
               new Claim("Id", Id),  //this provdes access in the controllers to the user id
               new Claim(ClaimTypes.Email, Email),
               new Claim(ClaimTypes.Name, Username)
            };
            var userIdentity = new ClaimsIdentity(claims, "login");
            _principal = new ClaimsPrincipal(userIdentity);
        }
    }
}