using System.Collections.Generic;
using Project.Domain.Model;

namespace Project.ViewModels.Order
{
    public class OrderViewModel
    {
        public IEnumerable<IOrder> Orders { get; set; }

        public IOrder Order { get; set; }

        public IEnumerable<ICustomer>  Customers { get; set; }
    }
}
