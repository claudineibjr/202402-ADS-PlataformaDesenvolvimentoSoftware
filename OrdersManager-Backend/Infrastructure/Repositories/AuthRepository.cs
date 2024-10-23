using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly OrdersDbContext _context;

        public AuthRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerByEmailAndPassword(string email, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
        }
    }
}
