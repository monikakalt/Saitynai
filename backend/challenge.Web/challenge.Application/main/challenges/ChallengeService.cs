using AutoMapper;
using challenge.Application.main.challenges.dto;
using challenge.EF.entities;
using challenge.EF.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.challenges
{
    public class ChallengeService: IChallengeService
    {
        protected readonly IChallengeRepository _challengeRepository;
        protected readonly IMapper _mapper;

        public ChallengeService(IChallengeRepository challengeRepository, IMapper mapper)
        {
            _challengeRepository = challengeRepository;
            _mapper = mapper;
        }

        public IEnumerable<ChallengeDto> GetAllChallenges()
        {
            var list = _challengeRepository.GetChallenges();
            var listDto = _mapper.Map<List<ChallengeDto>>(list);
            return listDto;
        }

        public void PostChallenge(ChallengeDto challenge)
        {
            // var ch = _challengeRepository.PostChallenge(challenge);
            var challengeDto = _mapper.Map<Challenges>(challenge);
            _challengeRepository.PostChallenge(challengeDto);
        }


        public ChallengeDto GetChallengeById(int id) {
            var challenge = _challengeRepository.GetChallengeById(id);
            var challengeDto = _mapper.Map<ChallengeDto>(challenge);
            return challengeDto;
        }
    }
}
