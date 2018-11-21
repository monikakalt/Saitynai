using challenge.Application.main.challenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.users.dto
{
    public class UsersDto
    {
        public UsersDto()
        {
           UsersChallenges = new HashSet<ChallengeViewDto>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImgUrl { get; set; }
        public int Points { get; set; }
        public int Level { get; set; }
        public string Token { get; set; }

        public ICollection<ChallengeViewDto> UsersChallenges { get; set; }


    }
}
