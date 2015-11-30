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
        public ActionResult Product(string productId)
        {
            if (productId == null)
            {
                return View("_noproduct");
            }

            return View(new ProductViewModel
            {
                Product = _productRepository.GetProduct(productId)
            });
        }
    }
}