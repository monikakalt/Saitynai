using challenge.EF.entities;
using System.Collections.Generic;
using System.Linq;

namespace challenge.EF.repositories
{
    public interface IChallengeRepository
    {
        //  IQueryable<Challenges> GetChallenges();
        List<Challenges> GetChallenges();
        Challenges GetChallengeById(int id);
        void PostChallenge(Challenges challenge);

    }
}
