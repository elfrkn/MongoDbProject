using MongoDbProject.Dtos.CustomerDtos;

namespace MongoDbProject.Models
{
    public class OrderWithCustomerListPdfViewModel
    {
        public string OrderProductName { get; set; }
        public string OrderProductPiece { get; set; }
        public string CustomerId { get; set; }
        public ResultCustomerDto Customer { get; set; }
    }
}
