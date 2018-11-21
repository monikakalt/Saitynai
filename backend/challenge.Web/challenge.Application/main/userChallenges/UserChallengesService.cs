using AutoMapper;
using challenge.Application.main.challenges.dto;
using challenge.Application.main.userChallenges.dto;
using challenge.EF.entities;
using challenge.EF.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.userChallenges
{
    public class UserChallengesService: IUserChallengesService
    {
        protected readonly IUserChallengeRepository _repository;
        protected readonly IMapper _mapper;

        public UserChallengesService(IUserChallengeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<UserChallengesDto> GetUserChallengesById(int id)
        {
            var list = _repository.GetUserChallengesById(id);
            var listDto = _mapper.Map<List<UserChallengesDto>>(list);
            return listDto;
        }

        public UserChallengesDto GetUserChallengesByIdChallengeId(int id, int userId)
        {
            var list = _repository.GetUserChallengeById(id, userId);
            var listDto = _mapper.Map<UserChallengesDto>(list);
            return listDto;
        }

        public UserChallengesDto PostAcceptChallenge(int id, int userId)
        {
            var ch = _repository.PostAcceptChallenge(id, userId);
            var chDto = _mapper.Map<UserChallengesDto>(ch);
            return chDto;

        }

        public void UpdateUserChallenge(int id, int userId, UserChallengesDto item)
        {
            var challenge = _mapper.Map<UsersChallenges>(item);
            _repository.UpdateUserChallenge(id, userId);

        }

        public void DeleteUserChallenge(int id, int userId)
        {
            _repository.DeleteUserChallenge(id, userId);
        }
    }
}
