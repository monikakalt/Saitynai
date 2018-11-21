using System;
using System.Collections.Generic;

namespace challenge.EF.entities
{
    public partial class UsersChallenges
    {
       

        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public int State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Challenges Challenge { get; set; }
        public Users User { get; set; }
    }
}
