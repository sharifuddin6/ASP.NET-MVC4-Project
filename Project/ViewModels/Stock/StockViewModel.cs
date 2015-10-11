using System.Collections.Generic;
using Project.Domain.Repositories;

namespace Project.ViewModels.Stock
{
    public class StockViewModel
    {
        public IEnumerable<IProduct> Products { get; set; }

        public IProduct Product { get; set; }
    }
}
