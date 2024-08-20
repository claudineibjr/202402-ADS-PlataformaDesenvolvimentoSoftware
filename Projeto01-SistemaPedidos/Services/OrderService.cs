using Projeto01_OrdersManager.DTOs;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories;

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

        private async Task<Order> _GetOrderBasedOnItsDTO(OrderDTO orderDTO, string existingOrderId)
        {
            Order order = await _GetOrderAndItsData(orderDTO);
            order.Id = existingOrderId;

            return order;
        }

        private async Task<Order> _GetOrderAndItsData(OrderDTO orderDTO)
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

            return order;
        }

        public async Task<Order> CreateOrder(OrderDTO orderDTO)
        {
            Order order = await _GetOrderAndItsData(orderDTO);

            order = await _orderRepository.SaveOrder(order);

            return order;
        }

        public async Task<Order> UpdateOrder(string orderId, OrderDTO orderDTO)
        {
            Order existingOrder = await _orderRepository.GetOrder(orderId);

            Order newOrder = await _GetOrderBasedOnItsDTO(orderDTO, orderId);
            await _orderRepository.UpdateOrder(existingOrder, newOrder);

            return newOrder;
        }
    }
}
