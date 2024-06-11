namespace MongoDbProject.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public string OrderProductName { get; set; }
        public string OrderProductPiece { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
    }
}
