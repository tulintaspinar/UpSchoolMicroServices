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
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();
            return CreateActionResultInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _productService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO createProductDTO)
        {
            var response = await _productService.CreateAsync(createProductDTO);
            return CreateActionResultInstance(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDTO updateProductDTO)
        {
            var response = await _productService.UpdateAsync(updateProductDTO);
            return CreateActionResultInstance(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response= await _productService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }
    }
}
