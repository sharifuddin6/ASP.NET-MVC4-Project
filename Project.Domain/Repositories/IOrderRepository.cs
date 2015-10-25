using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order.Order> GetAllOrders();

        void AddNewOrder(Order.Order order);

        void RemoveOrder(int id);
    }
}
