using System.Collections.Generic;
using Project.Domain.Repositories;

namespace Project.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<IOrder> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewOrder(int customerId, int productId, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveOrder(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
