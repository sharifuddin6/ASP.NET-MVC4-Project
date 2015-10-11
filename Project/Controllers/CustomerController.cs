using System.Web.Mvc;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Customer()
        {
            return View("Customer");
        }
    }
}