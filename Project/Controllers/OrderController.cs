using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Domain.Order;
using Project.Domain.Repositories;
using Project.ViewModels.Order;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderController(IOrderRepository orderRepository, 
                               ICustomerRepository customerRepository, 
                               IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult Order()
        {
            var order = new Order();
            var orders = _orderRepository.GetAllOrders();
            var customers = _customerRepository.GetAllCustomers();
            var products = _productRepository.GetAllProducts();

            IEnumerable<SelectListItem> customerList = customers.Select(item => new SelectListItem()
            {
                Text = item.Email,
                Value = item.Id.ToString()
            }).ToList();
            order.Customers = customerList;

            IEnumerable<SelectListItem> productList = products.Select(item => new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();
            order.Products = productList;


            return View(new OrderViewModel
            {
                Orders = orders,
                Order = order
            });
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {
            _orderRepository.AddNewOrder(order);
            return RedirectToAction("Order");
        }
    }
}