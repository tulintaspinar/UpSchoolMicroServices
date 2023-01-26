using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Catalog.DTOs;
using UpSchoolECommerce.Services.Catalog.Models;
using UpSchoolECommerce.Services.Catalog.Settings;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IDatabaseSettings databaseSettings,IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task<ResponseDTO<ProductDTO>> CreateAsync(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(product);
            return ResponseDTO<ProductDTO>.Success(_mapper.Map<ProductDTO>(product),200);
        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(string id)
        {
            var result = await  _productCollection.DeleteOneAsync(x=>x.Id==id);
            if (result.DeletedCount > 0)
            {
                return ResponseDTO<NoContent>.Success(204);
            }
            else
            {
                return ResponseDTO<NoContent>.Fail("Silinecek ürün bulunamadı!",404);
            }
        }

        public async Task<ResponseDTO<List<ProductDTO>>> GetAllAsync()
        {
            var products = await _productCollection.Find(product => true).ToListAsync();
            return ResponseDTO<List<ProductDTO>>.Success(_mapper.Map<List<ProductDTO>>(products),200);
        }

        public async Task<ResponseDTO<ProductDTO>> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x=>x.Id== id).FirstOrDefaultAsync();
            if (product == null)
            {
                return ResponseDTO<ProductDTO>.Fail("Ürün bulunamadı!", 404);
            }
            else
            {
                return ResponseDTO<ProductDTO>.Success(_mapper.Map<ProductDTO>(product),200);
            }
        }

        public async Task<ResponseDTO<NoContent>> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            var updateProduct = _mapper.Map<Product>(updateProductDTO);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProduct.Id,updateProduct);
            if (result == null)
            {
                return ResponseDTO<NoContent>.Fail("Güncellenecek ürün değeri bulunamadı!", 404);
            }
            else
            {
                return ResponseDTO<NoContent>.Success(204);
            }
        }
    }
}
