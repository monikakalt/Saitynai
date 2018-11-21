using challenge.EF.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace challenge.EF.repositories
{
    public class CategoryRepository : Repository<ChallengeCategories>, ICategoryRepository
    {
        public CategoryRepository(challengeContext context) : base(context)
        {
        }

        public List<ChallengeCategories> GetCategories()
        {
            return challengeContext.ChallengeCategories
              .ToList();

        }
        public challengeContext challengeContext
        {
            get { return Context as challengeContext; }
        }
    }
}
