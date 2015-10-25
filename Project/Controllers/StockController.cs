using System.Web.Mvc;
using Project.Domain.Product;
using Project.Domain.Repositories;
using Project.ViewModels.Stock;

namespace Project.Controllers
{
    public class StockController : Controller
    {
        private readonly IProductRepository _productRepository;
        
        public StockController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public ActionResult Stock()
        {
            var products = _productRepository.GetAllProducts();

            return View(new StockViewModel
            {
                Products = products,
                Product = new Product()
            });
        }

        [HttpPost]
        public ActionResult Stock(Product product)
        {
            _productRepository.AddNewProduct(product);
            return RedirectToAction("Stock");
        }
    }
}