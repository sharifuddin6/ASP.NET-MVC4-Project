using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<ICustomer> GetAllCustomers();

        void AddNewCustomer(string firstname, string lastname, string email);

        void RemoveCustomer(int id);
    }
}
