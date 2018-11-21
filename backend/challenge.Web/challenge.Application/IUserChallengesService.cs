using challenge.Application.main.challenges.dto;
using challenge.Application.main.userChallenges.dto;
using System.Collections.Generic;

namespace challenge.Application.main.userChallenges
{
    public interface IUserChallengesService
    {
        IEnumerable<UserChallengesDto> GetUserChallengesById(int id);
        UserChallengesDto PostAcceptChallenge(int id, int userId);
        void DeleteUserChallenge(int id, int userId);
        void UpdateUserChallenge(int id, int userId, UserChallengesDto item);

        UserChallengesDto GetUserChallengesByIdChallengeId(int id, int userId);
    }
}