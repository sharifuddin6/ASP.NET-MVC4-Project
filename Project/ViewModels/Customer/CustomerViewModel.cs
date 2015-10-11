using System.Collections.Generic;
using Project.Domain.Repositories;
using Project.Infrastructure.Repositories;

namespace Project.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public IEnumerable<IProduct> Products { get; set; }

        public Product Product { get; set; }
    }
}
