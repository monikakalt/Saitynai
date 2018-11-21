using challenge.Application.main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Web.Controllers.category
{
    [Route("/[controller]")]
    [Authorize]
    public class CategoryController : Controller
    {
        protected readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);

        }
    }
}