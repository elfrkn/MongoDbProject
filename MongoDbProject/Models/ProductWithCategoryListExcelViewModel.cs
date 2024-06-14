using MongoDbProject.Dtos.CategoryDtos;

namespace MongoDbProject.Models
{
    public class ProductWithCategoryListExcelViewModel
    {
       
        public string? Name { get; set; }
        public string CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
