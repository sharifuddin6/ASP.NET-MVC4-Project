using System.Collections.Generic;
using System.Web.Mvc;
using Project.Domain.Find;

namespace Project.ViewModels.Find
{
    public class FindViewModel
    {
        public IEnumerable<Domain.Product.Product> Products { get; set; }

        public Search Search { get; set; }

        public IEnumerable<SelectListItem> SortMenu = new List<SelectListItem> {
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

        public SelectListItem SortOption { get; set; }
    }
}
