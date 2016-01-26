using System.Web.Mvc;
using Project.Domain;
using Project.Domain.Repositories;
using Project.ViewModels;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View("Product", new ProductViewModel()
            {
                Products = _productRepository.GetAllProducts(),
                Product = new Product()
            });
        }
    }
}