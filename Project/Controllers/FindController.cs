using Project.Domain.Repositories;
using System.Web.Mvc;
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

        public ActionResult Find()
        {
            return View("Find", new FindViewModel
            {
                Products = _productRepository.GetAllProducts()
            });
        }
    }
}