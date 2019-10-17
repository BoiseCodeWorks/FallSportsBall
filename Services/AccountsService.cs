using System;
using CanadianSportsball.Models;
using CanadianSportsball.Repositories;

namespace CanadianSportsball.Services
{
    public class AccountsService
    {
        private readonly AccountsRepository _repo;
        public AccountsService(AccountsRepository repo)
        {
            _repo = repo;
        }

        internal User Register(UserRegistration creds)
        {
            User user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.Email = creds.Email;
            user.Username = creds.Username;
            user.Hash = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            _repo.Register(user);
            user.Hash = null;
            return user;
        }

        internal User Login(UserLoginCreds creds)
        {
            User user = _repo.GetUserByEmail(creds.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash))
            {
                throw new Exception("Invalid Email or Password");
            }
            user.Hash = null;
            return user;
        }

        internal User GetUserById(string id)
        {
            User user = _repo.GetUserById(id);
            if (user == null) { throw new Exception("Invalid Request"); }
            user.Hash = null;
            return user;
        }
    }
}