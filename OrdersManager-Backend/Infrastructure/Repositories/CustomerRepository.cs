using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Data;
using Core.Models;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrdersDbContext _context;

        public CustomerRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomer(string customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}
