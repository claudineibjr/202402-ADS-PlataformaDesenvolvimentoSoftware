using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.DTOs;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrdersDbContext _context;

        public OrderController(OrdersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.
                Orders
                .Include(p => p.Customer)
                .Include(p => p.Products).ThenInclude(p => p.Product)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO orderDTO)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == orderDTO.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            List<Product> products = await _context
               .Products
               .Where(p => orderDTO.Products.Select(pi => pi.ProductId).Contains(p.Id))
               .ToListAsync();


            List<OrderItem> orderItems = orderDTO.
                Products
                .Select(pi => new OrderItem { Product = products.First(p => p.Id == pi.ProductId), Quantity = pi.Quantity })
                .ToList();

            Order order = new Order(
                customer: customer,
                products: orderItems,
                orderDate: DateTime.Now,
                totalAmount: products.Sum(p =>
                {
                    double itemQuantity = orderDTO.Products.FirstOrDefault(pi => pi.ProductId == p.Id)?.Quantity ?? 1;
                    return p.Price * itemQuantity;
                })
            );

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostOrder), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, OrderDTO orderDTO)
        {
            Order? existingOrder = await _context
                 .Orders
                 .Include(o => o.Customer)
                 .Include(o => o.Products).ThenInclude(p => p.Product)
                 .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null)
            {
                throw new Exception("Order not found");
            }

            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == orderDTO.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            List<Product> products = await _context
               .Products
               .Where(p => orderDTO.Products.Select(pi => pi.ProductId).Contains(p.Id))
               .ToListAsync();

            List<OrderItem> orderItems = orderDTO.
                Products
                .Select(pi => new OrderItem { Product = products.First(p => p.Id == pi.ProductId), Quantity = pi.Quantity })
                .ToList();

            Order newOrder = new Order(
                customer: customer,
                products: orderItems,
                orderDate: DateTime.Now,
                totalAmount: products.Sum(p =>
                {
                    double itemQuantity = orderDTO.Products.FirstOrDefault(pi => pi.ProductId == p.Id)?.Quantity ?? 1;
                    return p.Price * itemQuantity;
                })
            );

            newOrder.Id = existingOrder.Id;
            _context.Entry(existingOrder).CurrentValues.SetValues(newOrder);

            existingOrder.Customer = newOrder.Customer;

            existingOrder.Products.Clear();
            existingOrder.Products.AddRange(newOrder.Products);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
