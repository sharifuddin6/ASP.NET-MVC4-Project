using System.Collections.Generic;
using System.Linq;
using Project.Domain.Model;
using Project.Domain.Repositories;
using Project.Infrastructure.Model;
using Project.Infrastructure.Repositories.Entities;

namespace Project.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<ICustomer> GetAllCustomers()
        {
            using (var context = new EntityContainer())
            {
                return Enumerable.Cast<ICustomer>(context.pCustomers.Select(customer => new Customer
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email
                })).ToList();
            }
        }

        public void AddNewCustomer(ICustomer customer)
        {
            using (var context = new EntityContainer())
            {
                var pCustomer = new pCustomer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email
                };
                context.pCustomers.Add(pCustomer);
                context.SaveChanges();
            }
        }

        public void RemoveCustomer(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
