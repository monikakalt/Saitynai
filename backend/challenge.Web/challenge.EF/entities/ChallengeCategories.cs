using System;
using System.Collections.Generic;

namespace challenge.EF.entities
{
    public partial class ChallengeCategories
    {
        public ChallengeCategories()
        {
            Challenges = new HashSet<Challenges>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Challenges> Challenges { get; set; }
    }
}
