using System.Collections.Generic;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Catalog.DTOs;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategoryDTO>>> GetAllAsync();
        Task<ResponseDTO<CategoryDTO>> CreateAsync(CategoryDTO categoryDTO);
        Task<ResponseDTO<CategoryDTO>> GetByIdAsync(string id);
    }
}
