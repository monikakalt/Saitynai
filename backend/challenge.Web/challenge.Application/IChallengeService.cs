using challenge.Application.main.challenges.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.challenges
{
    public interface IChallengeService
    {
        IEnumerable<ChallengeDto> GetAllChallenges();
        ChallengeDto GetChallengeById(int id);
        void PostChallenge(ChallengeDto challenge);
    }
}
