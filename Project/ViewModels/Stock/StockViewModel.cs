using System.Collections.Generic;
using Project.Domain.Product;

namespace Project.ViewModels.Stock
{
    public class StockViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public Product Product { get; set; }
    }
}
