﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MongoDbProject.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string OrderId { get; set; }
        public  string OrderProductName { get; set; }
        public  string OrderProductPiece { get; set; }

        [Column(TypeName ="Date")]
        public  DateTime OrderDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        [BsonIgnore]
        public  Customer Customer { get; set; }

    }
}
