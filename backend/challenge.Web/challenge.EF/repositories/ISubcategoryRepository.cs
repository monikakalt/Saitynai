using challenge.EF.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.EF.repositories
{
    public interface ISubcategoryRepository
    {
        List<ChallengeSubcategories> GetSubCategories();
        ChallengeSubcategories GetSubcategoryById(int id);
        void PostSubcategory(ChallengeSubcategories subcat);
        void DeleteSubcategory(int id);
        void UpdateSubcategory(int id, ChallengeSubcategories subcategory);
    }
}
