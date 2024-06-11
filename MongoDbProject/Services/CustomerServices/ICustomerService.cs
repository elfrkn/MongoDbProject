using MongoDbProject.Dtos.CategoryDtos;
using MongoDbProject.Dtos.CustomerDtos;

namespace MongoDbProject.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task CreateCustomerAsync(CreateCustomerDto customerDto);
        Task UpdateCustomerAsync(UpdateCustomerDto customerDto);
        Task DeleteCustomerAsync(string id);
        Task<GetByIdCustomerDto> GetByIdCustomerAsync(string id);
    }
}
