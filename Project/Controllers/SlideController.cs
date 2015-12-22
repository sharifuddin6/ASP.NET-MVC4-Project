using System.Web.Mvc;

namespace Project.Controllers
{
    public class SlideController : Controller
    {
        public ActionResult Index()
        {
            return View("Slide");
        }
    }
}