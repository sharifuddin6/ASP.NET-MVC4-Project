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
            var sortMenu = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "Relevance",
                    Value = "0"
                },
                new SelectListItem()
                {
                    Text = "SortExample1",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text = "SortExample2",
                    Value = "2"
                }
            };

            return View("Find", new FindViewModel
            {
                Products = _productRepository.GetAllProducts(),
                Search = new Search(),
                SortMenu = sortMenu
            });
        }

        [HttpPost]
        public ActionResult Find(string query, Search.SearchMethod selection)
        {
            if (query != "")
            {
                return PartialView("_listProducts", new FindViewModel
                {
                    Products = _productRepository.QueryProducts(query, selection)
                });
            }
            return PartialView("_listProducts", new FindViewModel
            {
                Products = _productRepository.GetAllProducts()
            });
        }
    }
}