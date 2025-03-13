using AutoMapper;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Service;
using DomainLayer.Model;
using DomainLayer.categoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Icategorieservice _icategorieservice;
        IMapper _imapper;

        public CategoryController(Icategorieservice icategorieservice, IMapper imapper)
        {
            _icategorieservice = icategorieservice;
            _imapper = imapper;
        }

        //endpoint to get all categories
        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_imapper.Map<List<CategoryDto>>(_icategorieservice.GetAllcategory()));

        }

        //endpoint to get one category
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category? category = _icategorieservice.Getcategory(id);

            if (category == null)
            {
                return NotFound();
            }

            CategoryDto existingcategory = _imapper.Map<CategoryDto>(category);

            return Ok(existingcategory);
        }

        //endpoint to create category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto categorydto)
        {
            Category newcategory = _imapper.Map<Category>(categorydto);

            Category? craetecategory = _icategorieservice.Createcategory(newcategory, out string message);

            if (craetecategory == null)
            {
                return BadRequest(message);
            }

            CategoryDto existingcategory = _imapper.Map<CategoryDto>(craetecategory);

            return Ok(existingcategory);
        }

        //endpoint to update a category
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDto categorydto)
        {
            Category existingcategory = _imapper.Map<Category>(categorydto);

            Category? categoryUpdate = _icategorieservice.Updatecategory(existingcategory, out string message);

            if (categoryUpdate is null)
            {
                return BadRequest(message);
            }

            CategoryDto newcategory = _imapper.Map<CategoryDto>(categoryUpdate);

            return Ok(newcategory);
        }

        //endpoint to delete a category
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(string id)
        {
            string message;
            bool isDeleted = _icategorieservice.Deletecategory(int.Parse(id), out message);
            if (!isDeleted)
            {
                return BadRequest();
            }
            return Ok(new { Message = "Deleted successfully" });
        }
    }
}
