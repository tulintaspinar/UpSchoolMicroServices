using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Catalog.DTOs;
using UpSchoolECommerce.Services.Catalog.Services;
using UpSchoolECommerce.Shared.ControllerBases;

namespace UpSchoolECommerce.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            var response = await _categoryService.CreateAsync(categoryDTO);
            return CreateActionResultInstance<CategoryDTO>(response);
        }
    }
}
