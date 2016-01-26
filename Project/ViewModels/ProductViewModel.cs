using System.Collections.Generic;
using Project.Domain;

namespace Project.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }
    }
}