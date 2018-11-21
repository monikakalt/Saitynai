using challenge.Application.main.subcategories.dto;
using challenge.EF.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application
{
    public interface ISubcategoryService
    {
        IEnumerable<SubcategoryDto> GetAllSubCategories();
        SubcategoryDto GetSubcategoryById(int id);
        void DeleteSubcategory(int id);
        ChallengeSubcategories PostSubcategory(SubcategoryDto item);
        void UpdateSubcategory(int id, SubcategoryDto subcategory);
    }
}
