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
                Products = _productRepository.GetAllProducts()
            });
        }

        [HttpGet]
        public ActionResult Search(string query, Search.SearchMethod method, Search.SortBy sort)
        {
            var products = string.IsNullOrEmpty(query) ? _productRepository.GetAllProducts() :
                                                         _productRepository.QueryProducts(query, method, sort);
            return View("Find", new FindViewModel
            {
                Products = products,
                Query = query,
                Method = method,
                Sort = sort
            });
        }
    }
}