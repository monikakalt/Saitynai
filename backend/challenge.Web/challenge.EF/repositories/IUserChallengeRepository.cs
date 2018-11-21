using challenge.EF.entities;
using System.Collections.Generic;

namespace challenge.EF.repositories
{
    public interface IUserChallengeRepository
    {
        List<UsersChallenges> GetUserChallengesById(int id);
        UsersChallenges PostAcceptChallenge(int id, int userId);
        void DeleteUserChallenge(int id, int userId);
        void UpdateUserChallenge(int id, int userId);

        UsersChallenges GetUserChallengeById(int id, int userId);
    }
    
}