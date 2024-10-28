using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrdersDbContext _context;

        public OrderRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByCustomer(string customerId)
        {
            return await _context
                .Orders
                .Include(o => o.Customer)
                .Include(o => o.Products).ThenInclude(p => p.Product)
                .Where(o => o.Customer.Id == customerId)
                .ToListAsync();
        }

        public async Task<Order> SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
