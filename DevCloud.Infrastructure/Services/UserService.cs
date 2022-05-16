using DevCloud.Core.Entities;
using DevCloud.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCloud.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly DevCloudContext _db;

        public UserService(DevCloudContext db)
        {
            _db = db;
        }

        public async Task Create(User newUser)
        {
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByLoginPassword(string login, string password)
        {
            var user = await GetByLogin(login);
            if (user == null) return null;

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            PasswordVerificationResult result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed) return null;

            return user;
        }

        public async Task<User> GetByLogin(string login) => await _db.Users.FirstOrDefaultAsync(u => u.Login.Equals(login));
    }
}
