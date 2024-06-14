using AutoMapper;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2010.Excel;
using MongoDB.Driver;
using MongoDbProject.Dtos.OrderDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Entities;
using MongoDbProject.Models;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMongoCollection<Product> _productCollection;

        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _orderCollection = database.GetCollection<Order>(_databaseSettings.OrderCollectionName);
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;

        }

        public async Task CreateOrderAsync(CreateOrderDto orderDto)
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();
            var product = await _productCollection.Find(x => x.ProductId == x.ProductId).FirstOrDefaultAsync();
            if (product.Stock > 0)
            {
                product.Stock = product.Stock - orderDto.OrderProductPiece;
                var value = _mapper.Map<Order>(orderDto);
                await _orderCollection.InsertOneAsync(value);
                await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == product.ProductId, product);
            }
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _orderCollection.DeleteOneAsync(x => x.OrderId == id);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(values);
        }

        public async Task<GetByIdOrderDto> GetByIdOrderAsync(string id)
        {
            var value = await _orderCollection.Find(x => x.OrderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOrderDto>(value);
        }

        public async Task<List<OrderWithCustomerListPdfViewModel>> GetOrderListViewModels()
        {
            var values = await _orderCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Customer = await _customerCollection.Find(x => x.CustomerId == item.CustomerId).FirstAsync();
            }
            return _mapper.Map<List<OrderWithCustomerListPdfViewModel>>(values);
        }

        public async Task<List<ResultOrderWithCustomerWithProductDto>> ResultOrderWithCustomerWithProductDto()
        {
            var values = await _orderCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Customer = await _customerCollection.Find(x => x.CustomerId == item.CustomerId).FirstAsync();
                item.Product = await _productCollection.Find(x => x.ProductId == item.ProductId).FirstAsync();
            }
            return _mapper.Map<List<ResultOrderWithCustomerWithProductDto>>(values);

        }

        public async Task UpdateOrderAsync(UpdateOrderDto orderDto)
        {
            var values = _mapper.Map<Order>(orderDto);
            await _orderCollection.FindOneAndReplaceAsync(x => x.OrderId == orderDto.OrderId, values);
        }
    }
}
