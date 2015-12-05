using Project.Domain.Repositories;
using System.Web.Mvc;
using Project.Domain.Find;
using Project.ViewModels.Find;

namespace Project.Controllers
{
    public class FindController : Controller
    {
        private readonly IProductRepository _productRepository;

        public FindController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Find", new FindViewModel
            {
                Products = _productRepository.GetAllProducts(),
                Search = new Search()
            });
        }

        [HttpGet]
        public ActionResult Search(string query, Search.SearchMethod method)
        {
            var products = string.IsNullOrEmpty(query) ? _productRepository.GetAllProducts() :
                                                         _productRepository.QueryProducts(query, method);
            return View("Find", new FindViewModel
            {
                Products = products,
                Search = new Search()
            });
        }
    }
}