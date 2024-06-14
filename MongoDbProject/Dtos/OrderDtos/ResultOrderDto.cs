namespace MongoDbProject.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public string OrderId { get; set; }
        public int OrderProductPiece { get; set; }
        public DateTime OrderDate { get; set; }
        public string? CustomerId { get; set; }
        public string? ProductId { get; set; }
    }
}
