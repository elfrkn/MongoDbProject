using MongoDbProject.Dtos.CategoryDtos;

namespace MongoDbProject.Dtos.ProductDtos
{
    public class ResultProductsWithCategoryDto
    {
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }

    }
}
