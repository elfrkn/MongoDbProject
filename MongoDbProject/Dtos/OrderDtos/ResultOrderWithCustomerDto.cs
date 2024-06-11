using MongoDbProject.Dtos.CustomerDtos;

namespace MongoDbProject.Dtos.OrderDtos
{
    public class ResultOrderWithCustomerDto
    {
        public string OrderId { get; set; }
        public string OrderProductName { get; set; }
        public string OrderProductPiece { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public ResultCustomerDto Customer { get; set; }
    }
}
