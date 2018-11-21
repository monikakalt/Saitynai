using System;
using System.Collections.Generic;

namespace challenge.EF.entities
{
    public partial class Users
    {
        public Users()
        {
            UsersChallenges = new HashSet<UsersChallenges>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImgUrl { get; set; }
        public int Points { get; set; }
        public int Level { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
       //  public string Token { get; set; }


        public ICollection<UsersChallenges> UsersChallenges { get; set; }
    }
}