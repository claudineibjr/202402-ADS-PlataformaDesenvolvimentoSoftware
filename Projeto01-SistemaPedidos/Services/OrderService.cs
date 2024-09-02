using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.DTOs;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager.Services
{
    public class OrderService
    {
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly OrderRepository _orderRepository;

        public OrderService(CustomerService customerService, ProductService productService, OrderRepository orderRepository)
        {
            _customerService = customerService;
            _productService = productService;
            _orderRepository = orderRepository;
        }

        public async Task<Order> SaveOrder(OrderDTO orderDTO)
        {
            Customer customer = await _customerService.GetCustomerOrThrowException(orderDTO.CustomerId);

            List<Product> products = await _productService.GetProducts(orderDTO.Products.Select(pi => pi.ProductId).ToList());

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
