using System.Collections.Generic;

namespace Project.ViewModels.Order
{
    public class OrderViewModel
    {
        public IEnumerable<Domain.Order.Order> Orders { get; set; }

        public Domain.Order.Order Order { get; set; }

        public IEnumerable<Domain.Customer.Customer>  Customers { get; set; }
    }
}
