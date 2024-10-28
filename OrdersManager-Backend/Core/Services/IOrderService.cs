using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrdersByCustomer(string customerId);
        public Task<Order> SaveOrder(string customerId, ICollection<ProductItemDTO> products);
    }
}
