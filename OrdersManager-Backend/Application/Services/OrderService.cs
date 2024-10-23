using Core.Services;
using Core.DTOs;
using Core.Models;
using Core.Repositories;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;

        public OrderService(
            ICustomerService customerService,
            IProductService productService,
            IOrderRepository orderRepository,
            IPaymentService paymentService,
            INotificationService notificationService
        )
        {
            _customerService = customerService;
            _productService = productService;
            _orderRepository = orderRepository;
            _paymentService = paymentService;
            _notificationService = notificationService;
        }

        public async Task<Order> SaveOrder(string customerId, ICollection<ProductItemDTO> productsDTO)
        {
            Customer customer = await _customerService.GetCustomerOrThrowException(customerId);

            List<Product> products = await _productService.GetProducts(productsDTO.Select(pi => pi.ProductId).ToList());

            List<OrderItem> orderItems = productsDTO
                .Select(pi => new OrderItem { Product = products.First(p => p.Id == pi.ProductId), Quantity = pi.Quantity })
            .ToList();

            Order order = new Order(
                customer: customer,
                products: orderItems,
                orderDate: DateTime.Now
            );

            _paymentService.RequestPayment(order);

            _notificationService.SendNotification(order);

            order = await _orderRepository.SaveOrder(order);

            return order;
        }

    }
}
