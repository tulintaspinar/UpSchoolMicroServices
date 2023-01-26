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
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;

        }
        public async Task<ResponseDTO<CategoryDTO>> CreateAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryCollection.InsertOneAsync(category);
            return ResponseDTO<CategoryDTO>.Success(_mapper.Map<CategoryDTO>(category),200);
        }

        public async Task<ResponseDTO<List<CategoryDTO>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category=>true).ToListAsync();
            return ResponseDTO<List<CategoryDTO>>.Success(_mapper.Map<List<CategoryDTO>>(categories),200);
        }

        public async Task<ResponseDTO<CategoryDTO>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if(category == null)
            {
                return ResponseDTO<CategoryDTO>.Fail("Kategori bulunamadı!", 404);
            }
            else
            {
                return ResponseDTO<CategoryDTO>.Success(_mapper.Map<CategoryDTO>(category), 200);
            }
        }
    }
}
