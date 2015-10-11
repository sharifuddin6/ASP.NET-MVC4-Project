using System.Collections.Generic;
using Project.Domain.Repositories;
using Project.Infrastructure.Repositories;

namespace Project.ViewModels.Stock
{
    public class StockViewModel
    {
        public IEnumerable<IProduct> Products { get; set; }

        public Product Product { get; set; }
    }
}
