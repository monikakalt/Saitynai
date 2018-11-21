using AutoMapper;
using challenge.Application.main.subcategories.dto;
using challenge.EF.repositories;
using challenge.EF.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.subcategories
{
    public class SubcategoryService : ISubcategoryService
    {
        protected readonly ISubcategoryRepository _subcategoryRepository;
        protected readonly IMapper _mapper;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<SubcategoryDto> GetAllSubCategories()
        {
            var list = _subcategoryRepository.GetSubCategories();
            var listDto = _mapper.Map<List<SubcategoryDto>>(list);
            return listDto;
        }

        public ChallengeSubcategories PostSubcategory(SubcategoryDto item)
        {
            var sub = _mapper.Map<ChallengeSubcategories>(item);
            _subcategoryRepository.PostSubcategory(sub);
            return sub;
        }

        public void DeleteSubcategory(int id)
        {
            _subcategoryRepository.DeleteSubcategory(id);
        }

        public SubcategoryDto GetSubcategoryById(int id)
        {
            var challenge = _subcategoryRepository.GetSubcategoryById(id);
            var challengeDto = _mapper.Map<SubcategoryDto>(challenge);
            return challengeDto;
        }

        public void UpdateSubcategory(int id, SubcategoryDto subcategory)
        {
            var sub = _mapper.Map<ChallengeSubcategories>(subcategory);
            _subcategoryRepository.UpdateSubcategory(id, sub);
        }
    }
}
