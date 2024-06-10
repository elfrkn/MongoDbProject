using AutoMapper;

using MongoDbProject.Dtos.CategoryDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Entities;

namespace MongoDbProject.Mapping
{
    public class GenericMapping :Profile
    {
        public GenericMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
        }
    }
}
