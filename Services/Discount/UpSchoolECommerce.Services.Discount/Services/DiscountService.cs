using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<ResponseDTO<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("DELETE FROM discount WHERE ID=@id", new
            {
                id = id
            });
            return status > 0 ? ResponseDTO<NoContent>.Success(204):ResponseDTO<NoContent>.Fail("Silinecek değer bulunamadı!",404);
        }

        public async Task<ResponseDTO<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("SELECT * FROM discount");
            return ResponseDTO<List<Models.Discount>>.Success(discounts.ToList(),200);
        }

        public Task<ResponseDTO<List<Models.Discount>>> GetByCodeUserId(string code, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDTO<Models.Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("SELECT * FROM discount WHERE ID=@id",new
            {
                id=id
            })).SingleOrDefault();
            return ResponseDTO<Models.Discount>.Success(discount, 200);
        }

        public async Task<ResponseDTO<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("INSERT INTO discount(userid,rate,code) VALUES(@UserId,@Rate,@Code)",discount);
            if (status > 0)
            {
                return ResponseDTO<NoContent>.Success(204);
            }
            return ResponseDTO<NoContent>.Fail("Hata oluştu!", 500);
        }

        public async Task<ResponseDTO<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("UPDATE discount SET userid=@UserId,rate=@Rate,code=@Code WHERE id=@ID",discount);
            if (status > 0)
            {
                return ResponseDTO<NoContent>.Success(204);
            }
            return ResponseDTO<NoContent>.Fail("Hata oluştu!", 500);
        }
    }
}
