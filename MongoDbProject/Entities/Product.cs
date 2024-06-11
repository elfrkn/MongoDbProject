using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MongoDbProject.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string? ProductId { get; set; }
        public  string? Name { get; set; }
        public  int Stock { get; set; }
        public  decimal Price { get; set; }
        public  string? ImageUrl { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }

    }
}
