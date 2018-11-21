using challenge.Application.main.challenges.dto;
using challenge.EF.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.userChallenges.dto
{
    public class UserChallengesDto
    {
        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public int State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ChallengeDto Challenge { get; set; }
        public Users User { get; set; }
    }
}
