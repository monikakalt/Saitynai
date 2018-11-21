using challenge.EF.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace challenge.EF.repositories
{
    public class ChallengeRepository : Repository<Challenges>, IChallengeRepository
    {
        public ChallengeRepository(challengeContext context) : base(context)
        {
        }


        public List<Challenges> GetChallenges()
        {
            return challengeContext.Challenges
           //   .Include(p => p.SubcategoryNavigation)
              .ToList();
        }


        public Challenges GetChallengeById(int id) {
            return challengeContext.Challenges
                .SingleOrDefault(p => p.Id == id);
        }

        public void PostChallenge(Challenges challenge)
        {
            challengeContext.Challenges.Add(challenge);
            challengeContext.SaveChanges();

        }
        public challengeContext challengeContext
        {
            get { return Context as challengeContext; }
        }
    }
}


/*       public IQueryable<Challenges> GetChallenges()
        {

            DbSet<Challenges> challenges = challengeContext.Challenges;
            DbSet<ChallengeCategories> categories = challengeContext.ChallengeCategories;

            return challenges.Join(
                categories,
                ch => ch.Category,
                cc => cc.Id,
                (ch, cc) => new Challenges()
                {
                    Id = ch.Id,
                    Title = ch.Title,
                    CreatedAt = ch.CreatedAt,
                    DaysNeeded = ch.DaysNeeded,
                    Reward = ch.Reward,
                    Difficulty = ch.Difficulty,
                    CompletedBy = ch.CompletedBy,
                    ImgUrl = ch.ImgUrl,
                    Subcategory = cc.Id,
                    Category = cc.Id,
                  //  Subcategory = cc.Title,
                 //   Category = cc.Title,
                    Instructions = ch.Instructions
                });

        }
*/