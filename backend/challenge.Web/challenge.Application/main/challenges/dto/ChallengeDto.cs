using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.challenges.dto
{
    public class ChallengeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DaysNeeded { get; set; }
        public int Reward { get; set; }
        public int Difficulty { get; set; }
        public int CompletedBy { get; set; }
        public string ImgUrl { get; set; }
        public int Subcategory { get; set; }
        public int  Category { get; set; }
        public string Instructions { get; set; }
    }
}
