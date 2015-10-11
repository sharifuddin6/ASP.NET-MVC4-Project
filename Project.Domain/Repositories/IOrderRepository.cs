using System.Collections.Generic;
using Project.Domain.Model;

namespace Project.Domain.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<IOrder> GetAllOrders();

        void AddNewOrder(IOrder order);

        void RemoveOrder(int id);
    }
}
