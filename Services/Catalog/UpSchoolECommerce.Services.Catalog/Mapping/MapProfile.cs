using AutoMapper;
using UpSchoolECommerce.Services.Catalog.DTOs;
using UpSchoolECommerce.Services.Catalog.Models;

namespace UpSchoolECommerce.Services.Catalog.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

        }
    }
}
