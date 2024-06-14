using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MongoDbProject.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string? OrderId { get; set; }
        public  int OrderProductPiece { get; set; }
        public  DateTime OrderDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CustomerId { get; set; }
        [BsonIgnore]
        public  Customer Customer { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
