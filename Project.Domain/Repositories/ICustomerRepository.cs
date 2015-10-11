using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<ICustomer> GetAllCustomers();

        void AddNewCustomer(ICustomer customer);

        void RemoveCustomer(int id);
    }
}
