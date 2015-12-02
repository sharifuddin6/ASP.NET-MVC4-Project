using System.Collections.Generic;
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
        public ActionResult Find()
        {
            return View("Find", new FindViewModel
            {
                Products = _productRepository.GetAllProducts(),
                Search = new Search()
            });
        }

        [HttpPost]
        public ActionResult Find(string query, Search.SearchMethod selection)
        {
            if (query != "")
            {
                return PartialView("_listProducts", new FindViewModel
                {
                    Products = _productRepository.QueryProducts(query, selection),
                    SortOption = new SelectListItem()
                    {
                        Text = "Relevance",
                        Value = "0"
                    }
                });
            }
            return PartialView("_listProducts", new FindViewModel
            {
                Products = _productRepository.GetAllProducts()
            });
        }
    }
}