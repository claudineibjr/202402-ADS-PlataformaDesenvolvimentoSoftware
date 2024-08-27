using Projeto01_OrdersManager.DTOs;
using Projeto01_OrdersManager.Models;
using Projeto01_OrdersManager.Repositories;

namespace Projeto01_OrdersManager.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        

        public OrderService(OrderRepository orderRepository, CustomerService customerService, ProductService productService)
        {
            _orderRepository = orderRepository;
            _customerService = customerService;
            _productService = productService;
        }

        private async Task<Order> GetOrderBasedOnItsDTO(OrderDTO orderDTO, string existingOrderId)
        {
            Order order = await GetOrderAndItsData(orderDTO);
            order.Id = existingOrderId;

            return order;
        }

        private async Task<Order> GetOrderAndItsData(OrderDTO orderDTO)
        {
            Customer customer = await _customerService.GetCustomer(orderDTO.CustomerId);

            List<Product> products = await _productService.GetProducts(orderDTO.Products.Select(pi => pi.ProductId));
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
            Order order = await GetOrderAndItsData(orderDTO);

            order = await _orderRepository.SaveOrder(order);

            return order;
        }

        public async Task<Order> UpdateOrder(string orderId, OrderDTO orderDTO)
        {
            Order existingOrder = await _orderRepository.GetOrder(orderId);

            Order newOrder = await GetOrderBasedOnItsDTO(orderDTO, orderId);
            await _orderRepository.UpdateOrder(existingOrder, newOrder);

            return newOrder;
        }
    }
}
