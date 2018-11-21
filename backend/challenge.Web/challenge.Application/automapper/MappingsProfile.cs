using challenge.Application.main.users.dto;
using challenge.Application.main.challenges;
using challenge.EF.entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using challenge.EF;
using challenge.Application.main.categories.dto;
using challenge.Application.main.subcategories.dto;
using challenge.Application.main.challenges.dto;
using challenge.Application.main.userChallenges.dto;

namespace challenge.Application.automapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Users, UsersDto>()
                .ForMember(dto => dto.UsersChallenges, 
                opt => opt.MapFrom(x => x.UsersChallenges
                .Select(y => y.Challenge).ToList()));

            CreateMap<UsersDto, Users>()
                .ForMember(dto => dto.UsersChallenges,
                opt => opt.MapFrom(x => x.UsersChallenges));

         
            CreateMap<Challenges, UsersDto>()
                .ForMember(dto => dto.UsersChallenges,
                opt => opt.MapFrom(x => x.UsersChallenges));
  
            CreateMap<ChallengeViewDto, UsersChallenges>()
                .ForMember(dto => dto.ChallengeId,
                opt => opt.MapFrom(x => x.Id));

            CreateMap<ChallengeCategories, CategoryDto>();
            CreateMap<ChallengeSubcategories, SubcategoryDto>();
            CreateMap<SubcategoryDto, ChallengeSubcategories>();

            CreateMap<Challenges, ChallengeDto>().ReverseMap();

          //  CreateMap<ChallengeDto, Challenges>();

            CreateMap<Challenges, ChallengeViewDto>();

            //-------------
            CreateMap<UsersChallenges, UserChallengesDto>()
                .ForMember(dto=>dto.Challenge, opt => opt.MapFrom(x => x.Challenge));
            CreateMap<UserChallengesDto, UsersChallenges>();
          //   CreateMap<ChallengeDto, UsersChallenges>()
            //     .ForMember(dto => dto.Challenge,
              //   opt => opt.MapFrom(x => x.Id));
            //  CreateMap<UserChallengesDto, UsersChallenges>();

        }
    }
}
