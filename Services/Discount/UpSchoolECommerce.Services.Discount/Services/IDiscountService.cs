using System.Collections.Generic;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Discount.Models;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<ResponseDTO<List<Models.Discount>>> GetAll();
        Task<ResponseDTO<Models.Discount>> GetById(int id);
        Task<ResponseDTO<NoContent>> Save(Models.Discount discount);
        Task<ResponseDTO<NoContent>> Update(Models.Discount discount);
        Task<ResponseDTO<NoContent>> Delete(int id);
        Task<ResponseDTO<List<Models.Discount>>> GetByCodeUserId(string code, string userId);
    }
}
