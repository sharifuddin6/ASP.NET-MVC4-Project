using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Project.Domain.Repositories;
using Project.ViewModels.Find;

namespace Project.Controllers
{
    public class FindController : Controller
    {
        private readonly ICollectionRepository collectionRepository;
        
        public FindController(ICollectionRepository collectionRepository)
        {
            this.collectionRepository = collectionRepository;
        }
        
        [HttpGet]
        public ActionResult Find()
        {
            var names = collectionRepository.GetAllItemsName();

            return View(new ListItemViewModel {Collection = names});
        }

        [HttpPost]
        public ActionResult Submit(FormCollection form)
        {
            var name = form["form_name"];
            var code = form["form_code"];

            collectionRepository.AddItem(name, code);
            return RedirectToAction("Find");
        }
    }
}