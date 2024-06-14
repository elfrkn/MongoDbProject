using AutoMapper;

using MongoDbProject.Dtos.CategoryDtos;
using MongoDbProject.Dtos.CustomerDtos;
using MongoDbProject.Dtos.OrderDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Entities;
using MongoDbProject.Models;

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
            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryListExcelViewModel>().ReverseMap();

            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();
           
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, GetByIdOrderDto>().ReverseMap();
            CreateMap<Order, ResultOrderWithCustomerWithProductDto>().ReverseMap();
            CreateMap<Order, OrderWithCustomerListPdfViewModel>().ReverseMap();
        }
    }
}
