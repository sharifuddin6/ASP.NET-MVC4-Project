using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<IOrder> GetAllOrders();

        void AddNewOrder(IOrder order);

        void RemoveOrder(int id);
    }
}
