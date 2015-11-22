using System.Web.Mvc;
using Project.Domain.Repositories;
using Project.ViewModels.Product;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public ActionResult Product()
        {
            var products = _productRepository.GetAllProducts();

            return View(new ProductViewModel
            {
                Products = products
            });
        }
    }
}