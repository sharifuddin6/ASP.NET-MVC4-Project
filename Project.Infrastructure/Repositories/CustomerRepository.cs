using System.Collections.Generic;
using Project.Domain.Repositories;

namespace Project.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<ICustomer> GetAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewCustomer(string firstname, string lastname, string email)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCustomer(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
