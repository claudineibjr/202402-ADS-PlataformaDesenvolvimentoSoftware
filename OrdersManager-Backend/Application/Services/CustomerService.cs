using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        private async Task<Customer?> GetCustomer(string customerId)
        {
            Customer? customer = await _customerRepository.GetCustomer(customerId);

            return customer;
        }

        public async Task<Customer> GetCustomerOrThrowException(string customerId)
        {
            Customer? customer = await GetCustomer(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            return customer;
        }
    }
}
