using CourierSystemDataLayer.Data;
using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Repository
{
    public class AuthAdminRepository : IAdminAuth
    {
        private readonly ApplicationDbContext db;
        public AuthAdminRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<AdminClass> Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var user = await db.admins.FirstOrDefaultAsync(x => x.Username == username);
                if (user != null)
                {
                    if (VerifyPassword(password, user.PasswordSalt, user.PasswordHash))
                    {
                        return user;
                    }
                }
            }
            return null;
        }
        private bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public async Task<AdminClass> RegisterUser(AdminClass admin, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            admin.PasswordSalt = passwordSalt;
            admin.PasswordHash = passwordHash;

            await db.AddAsync(admin);
            await db.SaveChangesAsync();

            return admin;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public async Task<bool> UserExist(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            if (await db.admins.AnyAsync(x => x.Username == username))
            {
                return true;
            }
            return false;
        }
    }
}
