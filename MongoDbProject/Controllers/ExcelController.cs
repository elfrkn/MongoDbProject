using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Models;
using MongoDbProject.Services.ProductServices;
using OfficeOpenXml;

namespace MongoDbProject.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IProductService _productService;

        public ExcelController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult ExcelList()
        {
            return View();
        }
        public async Task<IActionResult> ProductWithCategoryList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Ürün Listesi");
                workSheet.Cell(1, 1).Value = "Ürün Adı";
                workSheet.Cell(1, 2).Value = "Kategori";
                var model = await _productService.GetProductWithCategoryListExcelViewModelsAsync();

                int rowCount = 2;
                foreach (var item in model)
                {
                    workSheet.Cell(rowCount, 1).Value = item.Name;
                    workSheet.Cell(rowCount, 2).Value = item.Category.CategoryName;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProductList.xlsx");
                }

            }
        }
    }
}
