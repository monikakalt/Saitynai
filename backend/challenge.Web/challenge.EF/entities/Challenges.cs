using System;
using System.Collections.Generic;

namespace challenge.EF.entities
{
    public partial class Challenges
    {
        public Challenges()
        {
            UsersChallenges = new HashSet<UsersChallenges>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DaysNeeded { get; set; }
        public int Reward { get; set; }
        public byte Difficulty { get; set; }
        public int CompletedBy { get; set; }
        public string ImgUrl { get; set; }
        public int Category { get; set; }
        public int Subcategory { get; set; }
        public string Instructions { get; set; }

        public ChallengeCategories CategoryNavigation { get; set; }
      //  public ChallengeSubcategories SubcategoryNavigation { get; set; }
        public ICollection<UsersChallenges> UsersChallenges { get; set; }
    }
}
