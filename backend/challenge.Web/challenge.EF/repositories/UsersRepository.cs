using challenge.EF.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace challenge.EF.repositories
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(challengeContext context) : base(context)
        {
        }
 
        public List<Users> GetUsers()
        {
            return challengeContext.Users
              .Include(p => p.UsersChallenges)
             .ThenInclude(p => p.Challenge)
              .ToList();
        }

        public Users GetUserById(int id) {
            return challengeContext.Users
                .Include(p => p.UsersChallenges)
                .ThenInclude(p => p.Challenge)
                .SingleOrDefault(p => p.Id == id);
        }

        public Users Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = challengeContext.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public void Save (Users user)
        {
            if (challengeContext.Users.Any(x => x.Username == user.Username))
                throw new Exception("Username " + user.Username + " is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var u = new Users()
            {
                Id = user.Id,
                FullName = user.FullName,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                ImgUrl = "https://www.gravatar.com/avatar/" + MD5Hash(user.Email).ToString() + "?d=https://www.1plusx.com/app/mu-plugins/all-in-one-seo-pack-pro/images/default-user-image.png",
                Points = user.Points,
                Level = user.Points/500 + 1,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
            challengeContext.Add(u);
            challengeContext.SaveChanges();
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            //get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public challengeContext challengeContext
        {
            get { return Context as challengeContext; }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
