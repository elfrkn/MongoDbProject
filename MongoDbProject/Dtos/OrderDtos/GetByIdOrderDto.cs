namespace MongoDbProject.Dtos.OrderDtos
{
    public class GetByIdOrderDto
    {
        public string OrderId { get; set; }
        public string OrderProductName { get; set; }
        public string OrderProductPiece { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
    }
}
