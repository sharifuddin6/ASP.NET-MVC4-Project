using System.Collections.Generic;
using Project.Domain.Model;

namespace Project.Domain.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<ICustomer> GetAllCustomers();

        void AddNewCustomer(ICustomer customer);

        void RemoveCustomer(int id);
    }
}
