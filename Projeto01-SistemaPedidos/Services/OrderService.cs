using Projeto01_OrdersManager.DTOs;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderService(OrderRepository orderRepository, CustomerRepository customerRepository, ProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateOrder(OrderDTO orderDTO)
        {   
            Customer customer = await _customerRepository.GetCustomer(orderDTO.CustomerId);
            
            List<Product> products = await _productRepository.GetProducts(orderDTO.Products.Select(pi => pi.ProductId));
            List<OrderItem> orderItems = orderDTO.
                Products
                .Select(pi => new OrderItem { Product = products.First(p => p.Id == pi.ProductId), Quantity = pi.Quantity })
                .ToList();

            Order order = new Order(
                customer: customer,
                products: orderItems,
                orderDate: DateTime.Now
            );

            order = await _orderRepository.SaveOrder(order);

            return order;
        }
    }
}
