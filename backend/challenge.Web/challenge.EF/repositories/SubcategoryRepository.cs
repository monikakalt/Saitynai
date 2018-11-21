using challenge.EF.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace challenge.EF.repositories
{
    public class SubcategoryRepository : Repository<ChallengeSubcategories>, ISubcategoryRepository
    {
        public SubcategoryRepository(challengeContext context) : base(context)
        {
        }

        public List<ChallengeSubcategories> GetSubCategories()
        {
            return challengeContext.ChallengeSubcategories
              .ToList();
        }

        public void PostSubcategory(ChallengeSubcategories subcat)
        {
            challengeContext.Add(subcat);
            challengeContext.SaveChanges();
        }

        public void DeleteSubcategory(int id)
        {
            var ch = challengeContext.ChallengeSubcategories.SingleOrDefault(p => p.Id == id);
            challengeContext.Remove(ch);
            challengeContext.SaveChanges();
        }

        public void UpdateSubcategory(int id, ChallengeSubcategories subcategory)
        {
            var sub = challengeContext.ChallengeSubcategories.Where(p => id == p.Id).Single();
            sub.Title = subcategory.Title;
            challengeContext.SaveChanges();
        }

        public ChallengeSubcategories GetSubcategoryById(int id)
        {
            var sub = challengeContext.ChallengeSubcategories.Where(p => id == p.Id).Single();

            return sub;
        }

        public challengeContext challengeContext
        {
            get { return Context as challengeContext; }
        }
    }
}
