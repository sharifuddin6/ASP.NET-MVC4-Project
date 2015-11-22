using System.Collections.Generic;

namespace Project.ViewModels.Product
{
    public class ProductViewModel
    {
        public IEnumerable<Domain.Product.Product> Products { get; set; }
    }
}
