using System.Web.Mvc;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Order()
        {
            return View("Order");
        }
    }
}