using System.Collections.Generic;

namespace Project.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public IEnumerable<Domain.Customer.Customer> Customers { get; set; }

        public Domain.Customer.Customer Customer { get; set; }
    }
}
