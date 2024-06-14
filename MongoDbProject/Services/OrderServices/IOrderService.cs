using MongoDbProject.Dtos.OrderDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Models;

namespace MongoDbProject.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task CreateOrderAsync(CreateOrderDto productDto);
        Task UpdateOrderAsync(UpdateOrderDto productDto);
        Task DeleteOrderAsync(string id);
        Task<GetByIdOrderDto> GetByIdOrderAsync(string id);
        Task<List<ResultOrderWithCustomerWithProductDto>> ResultOrderWithCustomerWithProductDto();
        Task<List<OrderWithCustomerListPdfViewModel>> GetOrderListViewModels();
    }
}
