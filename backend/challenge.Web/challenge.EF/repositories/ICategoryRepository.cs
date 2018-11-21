using challenge.EF.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.EF.repositories
{
    public interface ICategoryRepository
    {
        List<ChallengeCategories> GetCategories();
    }
}
