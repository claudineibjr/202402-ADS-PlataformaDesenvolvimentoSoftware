using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Repositories
{
    public class CustomerRepository
    {
        private readonly OrdersDbContext _context;

        public CustomerRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomer(string customerId)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            return customer;
        }

    }
}
