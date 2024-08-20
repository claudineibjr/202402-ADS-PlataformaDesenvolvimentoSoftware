using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.DTOs;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Services
{
    public class OrderService
    {
        private readonly OrdersDbContext _context;

        public OrderService(OrdersDbContext context)
        {
            _context = context;
        }

        private double CalculateTotal(ICollection<Product> products, ICollection<ProductItemDTO> productItemsDTOs)
        {
            return products.Sum(p =>
            {
                double itemQuantity = productItemsDTOs.FirstOrDefault(pi => pi.ProductId == p.Id)?.Quantity ?? 1;
                return p.Price * itemQuantity;
            });
        }

        public async Task<Order> CreateOrder(OrderDTO orderDTO)
        {
            OrderRepository orderRepository = new OrderRepository(_context);
            CustomerRepository customerRepository = new CustomerRepository(_context);
            ProductRepository productRepository = new ProductRepository(_context);

            Customer customer = await customerRepository.GetCustomer(orderDTO.CustomerId);
            
            List<Product> products = await productRepository.GetProducts(orderDTO.Products.Select(pi => pi.ProductId));
            List<OrderItem> orderItems = orderDTO.
                Products
                .Select(pi => new OrderItem { Product = products.First(p => p.Id == pi.ProductId), Quantity = pi.Quantity })
                .ToList();

            Order order = new Order(
                customer: customer,
                products: orderItems,
                orderDate: DateTime.Now,
                totalAmout: CalculateTotal(products, orderDTO.Products)
            );

            order = await orderRepository.SaveOrder(order);

            return order;
        }
    }
}
