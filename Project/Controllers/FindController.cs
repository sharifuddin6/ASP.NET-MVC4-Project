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
                Products = _productRepository.QueryProducts(),
                TotalResult = _productRepository.QueryTotalResults()
            });
        }

        [HttpGet]
        public ActionResult Search(string query, Search.SearchMethod method, Search.SortBy sort, int page = 1)
        {
            var totalResults = _productRepository.QueryTotalResults(query, method);
            var products = _productRepository.QueryProducts(query, method, sort, page);
            return View("Find", new FindViewModel
            {
                Products = products,
                Query = query,
                Method = method,
                Sort = sort,
                Page =  page,
                TotalResult = totalResults
            });
        }
    }
}