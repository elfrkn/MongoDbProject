using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDbProject.Dtos.OrderDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Services.CustomerServices;
using MongoDbProject.Services.OrderServices;
using MongoDbProject.Services.ProductServices;

namespace MongoDbProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderServices;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;


        public OrderController(IOrderService orderServices, ICustomerService customerService, IProductService productService)
        {
            _orderServices = orderServices;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<IActionResult> OrderList()
        {
            var values = await _orderServices.ResultOrderWithCustomerDto();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            List<SelectListItem> values = (from x in await _customerService.GetAllCustomerAsync()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerNameSurname,
                                               Value = x.CustomerId.ToString()
                                           }).ToList();
            ViewBag.Customers = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _orderServices.CreateOrderAsync(createOrderDto);
            return RedirectToAction("OrderList");
        }
        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _orderServices.DeleteOrderAsync(id);
            return RedirectToAction("OrderList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(string id)
        {
            List<SelectListItem> values = (from x in await _customerService.GetAllCustomerAsync()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerNameSurname,
                                               Value = x.CustomerId.ToString()
                                           }).ToList();
            ViewBag.Customers = values;
            var value = await _orderServices.GetByIdOrderAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _orderServices.UpdateOrderAsync(updateOrderDto);
            return RedirectToAction("OrderList");
        }
    }
}
