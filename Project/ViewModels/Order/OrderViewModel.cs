using System.Collections.Generic;
using Project.Domain.Repositories;
using Project.Infrastructure.Repositories;

namespace Project.ViewModels.Order
{
    public class OrderViewModel
    {
        public IEnumerable<IProduct> Products { get; set; }

        public Product Product { get; set; }
    }
}
