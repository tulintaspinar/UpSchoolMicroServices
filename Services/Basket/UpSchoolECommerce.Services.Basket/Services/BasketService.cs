using System.Text.Json;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Basket.DTOs;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<ResponseDTO<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? ResponseDTO<bool>.Success(204) : ResponseDTO<bool>.Fail("Silinecek sepet bulunamadı!", 404);
        }

        public async Task<ResponseDTO<BasketDTO>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return ResponseDTO<BasketDTO>.Fail("Sepet bulunamadı!", 404);
            }
            else
            {
                return ResponseDTO<BasketDTO>.Success(JsonSerializer.Deserialize<BasketDTO>(existBasket), 200);
            }
        }

        public async Task<ResponseDTO<bool>> SaveOrUpdate(BasketDTO basketDTO)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDTO.UserId,JsonSerializer.Serialize(basketDTO));
            return status ? ResponseDTO<bool>.Success(204) : ResponseDTO<bool>.Fail("Hata oluştu!",500);
        }
    }
}
