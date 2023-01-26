using System.Collections.Generic;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Catalog.DTOs;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Catalog.Services
{
    public interface IProductService
    {
        Task<ResponseDTO<List<ProductDTO>>> GetAllAsync();
        Task<ResponseDTO<ProductDTO>> GetByIdAsync(string id);
        Task<ResponseDTO<ProductDTO>> CreateAsync(CreateProductDTO createProductDTO);
        Task<ResponseDTO<NoContent>> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<ResponseDTO<NoContent>> DeleteAsync(string id);
    }
}
