using System.Collections.Generic;
using Project.Domain.Model;

namespace Project.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public IEnumerable<ICustomer> Customers { get; set; }

        public ICustomer Customer { get; set; }
    }
}
