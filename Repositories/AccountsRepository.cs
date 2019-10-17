using System;
using System.Data;
using CanadianSportsball.Models;
using Dapper;

namespace CanadianSportsball.Repositories
{
    public class AccountsRepository
    {
        private readonly IDbConnection _db;
        public AccountsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal void Register(User user)
        {
            string sql = @"
            INSERT INTO users
            (id, username, email, hash)
            VALUES
            (@Id, @Username, @Email, @Hash)
            ";
            _db.Execute(sql, user);
        }

        internal User GetUserByEmail(string email)
        {
            string sql = "SELECT * FROM users WHERE email = @email";
            return _db.QueryFirstOrDefault<User>(sql, new { email });
        }

        internal User GetUserById(string id)
        {
            string sql = "SELECT * FROM users WHERE id = @id";
            return _db.QueryFirstOrDefault<User>(sql, new { id });
        }
    }
}