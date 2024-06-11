using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Dtos.OrderDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.OrderServices
{
    public class OrderService :IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IMongoCollection<Customer> _customerCollection;

        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _orderCollection = database.GetCollection<Order>(_databaseSettings.OrderCollectionName);
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _mapper = mapper;

        }

        public async Task CreateOrderAsync(CreateOrderDto orderDto)
        {
            var value = _mapper.Map<Order>(orderDto);
            await _orderCollection.InsertOneAsync(value);
        }

        public Task DeleteOrderAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdOrderDto> GetByIdOrderAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultOrderWithCustomerDto>> ResultOrderWithCustomerDto()
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(UpdateOrderDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
