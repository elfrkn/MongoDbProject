using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace MongoDbProject.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string CategoryId { get; set; }

    }
}
