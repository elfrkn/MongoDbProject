using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Models;

namespace MongoDbProject.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(UpdateProductDto productDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ProductWithCategoryListExcelViewModel>> GetProductWithCategoryListExcelViewModelsAsync();
    }
}
