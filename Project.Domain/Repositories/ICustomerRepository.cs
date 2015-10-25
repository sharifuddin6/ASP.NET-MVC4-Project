using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer.Customer> GetAllCustomers();

        void AddNewCustomer(Customer.Customer customer);

        void RemoveCustomer(int id);
    }
}
