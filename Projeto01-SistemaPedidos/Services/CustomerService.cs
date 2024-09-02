using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
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
