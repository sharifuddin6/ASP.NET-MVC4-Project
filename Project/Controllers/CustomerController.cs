using System.Web.Mvc;
using Project.Domain.Customer;
using Project.Domain.Repositories;
using Project.ViewModels.Customer;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Customer()
        {
            var customers = _customerRepository.GetAllCustomers();

            return View(new CustomerViewModel
            {
                Customers = customers,
                Customer = new Customer()
            });
        }

        [HttpPost]
        public ActionResult Customer(Customer customer)
        {
            _customerRepository.AddNewCustomer(customer);
            return RedirectToAction("Customer");
        }
    }
}