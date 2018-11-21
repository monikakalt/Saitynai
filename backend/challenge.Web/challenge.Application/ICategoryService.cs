using challenge.Application.main.categories.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
    }
}
