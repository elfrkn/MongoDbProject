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

        public async Task DeleteOrderAsync(string id)
        {
            await _orderCollection.DeleteOneAsync(x=>x.OrderId == id);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(values);
        }

        public async  Task<GetByIdOrderDto> GetByIdOrderAsync(string id)
        {
            var value =await _orderCollection.Find(x => x.OrderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOrderDto>(value);
        }

        public async Task<List<ResultOrderWithCustomerDto>> ResultOrderWithCustomerDto()
        {
            var values = await _orderCollection.Find(x => true).ToListAsync();
            foreach(var item in values)
            {
                item.Customer = await _customerCollection.Find(x => x.CustomerId == item.CustomerId).FirstAsync();
            }
            return _mapper.Map<List<ResultOrderWithCustomerDto>>(values);
            
        }

        public async Task UpdateOrderAsync(UpdateOrderDto orderDto)
        {
            var values = _mapper.Map<Order>(orderDto);
            await _orderCollection.FindOneAndReplaceAsync(x => x.OrderId == orderDto.OrderId, values);
        }
    }
}
