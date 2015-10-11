using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<IOrder> GetAllOrders();

        void AddNewOrder(int customerId, int productId, int quantity);

        void RemoveOrder(int id);
    }
}
