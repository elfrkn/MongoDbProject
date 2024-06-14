using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Services.CategoryServices;
using MongoDbProject.Services.GoogleCloud;
using MongoDbProject.Services.ProductServices;
using System.Security.Cryptography.Xml;

namespace MongoDbProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICloudStorageService _cloudStorageService;

        public ProductController(IProductService productService, ICategoryService categoryService, ICloudStorageService cloudStorageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            List<SelectListItem> values = (from x in await _categoryService.GetAllCategoryAsync()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.Categories = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            if (createProductDto.ImageUrl != null)
            {
                createProductDto.SavedFileName = GenerateFileNameToSave(createProductDto.ImageUrl.FileName);
                createProductDto.SavedUrl = await _cloudStorageService.UploadFileAsync(createProductDto.ImageUrl,createProductDto.SavedFileName);
            }

            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }

        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            List<SelectListItem> values = (from x in await _categoryService.GetAllCategoryAsync()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.Categories = values;
            var value = await _productService.GetByIdProductAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }
    }
}
