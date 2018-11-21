using challenge.EF.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace challenge.EF.repositories
{
    public class UserChallengeRepository: Repository<UsersChallenges>, IUserChallengeRepository
    {
        public UserChallengeRepository(challengeContext context) : base(context)
        {
        }

        public List<UsersChallenges> GetUserChallengesById(int id)
        {

            var userChallanges = ChallengeContext.UsersChallenges.Where(p => id == p.UserId).ToList();

            foreach(var uc in userChallanges)
            {
                foreach(var ch in ChallengeContext.Challenges)
                {
                    if(uc.ChallengeId == ch.Id)
                    {
                        uc.Challenge = ch;
                    }
                }
            }
            return userChallanges;
        }


        public UsersChallenges PostAcceptChallenge(int id, int userId)
        {
            var chal = ChallengeContext.Challenges.SingleOrDefault(p => p.Id == id);
            var user = ChallengeContext.Users.SingleOrDefault(p => p.Id == userId);
            DateTime today = DateTime.Parse(DateTime.Now.ToString());
            DateTime answer = today.AddDays(Convert.ToInt32(chal.DaysNeeded));

            var userCh = new UsersChallenges()
            {
                UserId = userId,
                ChallengeId = id,
                StartDate = DateTime.Now,
                EndDate = answer,
                Challenge = chal,
                User = user
                };
            ChallengeContext.UsersChallenges.Add(userCh);
            ChallengeContext.SaveChanges();
            return ChallengeContext.UsersChallenges.SingleOrDefault(p => p.UserId == userId && p.ChallengeId == id);
        }
        public void DeleteUserChallenge(int id, int userId)
        {
            var ch = ChallengeContext.UsersChallenges.SingleOrDefault(p => p.ChallengeId == id && p.UserId == userId);
            var challenge = ChallengeContext.Challenges.SingleOrDefault(p => p.Id == id);
            int taskai = (challenge.Reward/10);
            var usr = ChallengeContext.Users.SingleOrDefault(p => p.Id == userId);
            if(usr.Points - taskai >= 0)
            {
                usr.Points -= taskai;
            }
            else
            {
                usr.Points = 0;
            }
            ChallengeContext.UsersChallenges.Remove(ch);
            ChallengeContext.SaveChanges();
        }

        public void UpdateUserChallenge(int id, int userId)
        {
            var oldChallenge = GetUserChallengeById(id, userId);
            if (oldChallenge.State == 0)
            {
                oldChallenge.State = 1;
            }
            
            ChallengeContext.SaveChanges();
        }

        public UsersChallenges GetUserChallengeById(int id, int userId)
        {
            var userChallange = ChallengeContext.UsersChallenges.Where(p => id == p.ChallengeId && userId == p.UserId).Single();

            return userChallange;
        }

        public challengeContext ChallengeContext
        {
            get { return Context as challengeContext; }
        }
    }
}
