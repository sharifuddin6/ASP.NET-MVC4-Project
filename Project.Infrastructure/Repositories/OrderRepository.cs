using System.Collections.Generic;
using System.Linq;
using Project.Domain.Model;
using Project.Domain.Repositories;
using Project.Infrastructure.Model;
using Project.Infrastructure.Repositories.Entities;

namespace Project.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<IOrder> GetAllOrders()
        {
            using (var context = new EntityContainer())
            {
                return Enumerable.Cast<IOrder>(context.pOrdersViews.Select(order => new Order()
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId ?? 0,
                    Email = order.Email,
                    Name = order.Name,
                    ProductId = order.ProductId ?? 0,
                    Code = order.Code,
                    Value = (float) (order.Value ?? 0),
                    Quantity = order.Quantity ?? 0,
                    Total = (float) (order.Total ?? 0)
                })).ToList();
            }
        }

        public void AddNewOrder(IOrder order)
        {
            using (var context = new EntityContainer())
            {
                var pOrder = new pOrder()
                {
                    CustomerId = order.CustomerId,
                    ProductId = order.ProductId,
                    Quantity = order.Quantity
                };
                context.pOrders.Add(pOrder);
                context.SaveChanges();
            }
        }

        public void RemoveOrder(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
