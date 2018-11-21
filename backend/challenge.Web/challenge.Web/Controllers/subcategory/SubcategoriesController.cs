using challenge.Application;
using challenge.Application.main.subcategories.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace challenge.Web.Controllers.subcategory
{
    [Route("/[controller]")]
    [Authorize]
    public class SubcategoriesController : Controller
    {
        protected readonly ISubcategoryService _subcategoryService;
        public SubcategoriesController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var subcategories = _subcategoryService.GetAllSubCategories();
            return Ok(subcategories);

        }

        [HttpGet("{id}")]
        public IActionResult GetSubcategoryById(int id)
        {
            try
            {
                var sub = _subcategoryService.GetSubcategoryById(id);
                if (sub != null)
                    return new ObjectResult(sub);
                return NotFound();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Source);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult PostSubcategory([FromBody] SubcategoryDto subcategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var sub = _subcategoryService.PostSubcategory(subcategory);
                return Created("subcategories/" + sub.Id, sub);

            }
            catch (Exception err)
            {

            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutSubcategory(int id, [FromBody] SubcategoryDto subcategory)
        {
            try
            {
               _subcategoryService.UpdateSubcategory(id, subcategory);
                return Ok();

            }
            catch (Exception ex)
            {

            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSubcategory(int id)
        {
            try
            {
                 var sub = _subcategoryService.GetSubcategoryById(id); 
                _subcategoryService.DeleteSubcategory(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}