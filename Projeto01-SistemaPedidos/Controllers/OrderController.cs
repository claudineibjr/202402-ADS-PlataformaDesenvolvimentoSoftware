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
            return await _context.Orders.Include(p => p.Customer).Include(p => p.Products).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var order = await _context.Orders
                .Include(p => p.Customer)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        private async Task<Customer?> GetCustomer(string customerId)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            return customer;
        }

        private async Task<List<Product>> GetProducts(IEnumerable<string> productsIds)
        {
            List<Product> products = await _context
                .Products
                .Where(p => productsIds.Contains(p.Id))
                .ToListAsync();

            return products;
        }

        private double CalculateTotal(ICollection<Product> products, ICollection<ProductItemDTO> productItemsDTOs)
        {
            return products.Sum(p =>
            {
                double itemQuantity = productItemsDTOs.FirstOrDefault(pi => pi.ProductId == p.Id)?.Quantity ?? 1;
                return p.Price * itemQuantity;
            });
        }

        private async Task<Order> SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO orderDTO)
        {
            Customer? customer = await GetCustomer(orderDTO.CustomerId);   
            if (customer == null)
            {
                return BadRequest();
            }

            List<Product> products = await GetProducts(orderDTO.Products.Select(pi => pi.ProductId));

            Order order = new Order(
                customer: customer,
                products: products,
                orderDate: DateTime.Now,
                totalAmout: CalculateTotal(products, orderDTO.Products)
            );

            order = await SaveOrder(order);

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, OrderDTO orderDTO)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == orderDTO.CustomerId);
            if (customer == null)
            {
                return BadRequest();
            }

            List<Product> products = await _context.Products.Where(p => orderDTO.Products.Select(pi => pi.ProductId).Contains(p.Id)).ToListAsync();

            Order order = new Order(
                customer: customer,
                products: products,
                orderDate: DateTime.Now,
                totalAmout: products.Sum(p =>
                {
                    double itemQuantity = orderDTO.Products.FirstOrDefault(pi => pi.ProductId == p.Id)?.Quantity ?? 1;
                    return p.Price * itemQuantity;
                })
            );

            _context.Entry(orderDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orders.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
