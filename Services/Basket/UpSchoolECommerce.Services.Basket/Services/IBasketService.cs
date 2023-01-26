using System.Threading.Tasks;
using UpSchoolECommerce.Services.Basket.DTOs;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<ResponseDTO<BasketDTO>> GetBasket(string userId);
        Task<ResponseDTO<bool>> SaveOrUpdate(BasketDTO basketDTO);
        Task<ResponseDTO<bool>> Delete(string userId);
    }
}
