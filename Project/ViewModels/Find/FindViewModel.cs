using System.Collections.Generic;
using System.Web.Mvc;
using Project.Domain.Find;

namespace Project.ViewModels.Find
{
    public class FindViewModel
    {
        public IEnumerable<Domain.Product.Product> Products { get; set; }

        public Search Search { get; set; }

        public IEnumerable<SelectListItem> SortMenu { get; set; }

        public string SortOption { get; set; }
    }
}
