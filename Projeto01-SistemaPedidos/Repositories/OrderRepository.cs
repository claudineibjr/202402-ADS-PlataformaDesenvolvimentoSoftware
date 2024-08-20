using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Repositories
{
    public class OrderRepository
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

        public async Task<Order> GetOrder(string orderId)
        {
            Order? order = await _context
                .Orders
                .Include(o => o.Customer)
                .Include(o => o.Products).ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return order;
        }

        public async Task<Order> UpdateOrder(Order existingOrder, Order newOrder)
        {
            _context.Entry(existingOrder).CurrentValues.SetValues(newOrder);

            existingOrder.Customer = newOrder.Customer;

            existingOrder.Products.Clear();
            existingOrder.Products.AddRange(newOrder.Products);

            await _context.SaveChangesAsync();

            return newOrder;
        }
    }
}
