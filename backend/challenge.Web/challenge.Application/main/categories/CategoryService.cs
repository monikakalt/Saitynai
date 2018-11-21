using AutoMapper;
using challenge.Application.main.categories.dto;
using challenge.EF.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.categories
{
    public class CategoryService : ICategoryService
    {
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var list = _categoryRepository.GetCategories();
            var listDto = _mapper.Map<List<CategoryDto>>(list);
            return listDto;
        }
    }
}
