using System.Collections.Generic;
using Project.Domain.Find;

namespace Project.ViewModels.Find
{
    public class FindViewModel
    {
        public IEnumerable<Domain.Product.Product> Products { get; set; }

        public Search Search { get; set; }
    }
}
