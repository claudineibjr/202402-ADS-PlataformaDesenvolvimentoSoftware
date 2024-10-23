using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrdersDbContext _context;

        public OrderRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public async Task<Order> SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
