using Core.Models;

namespace Core.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> SaveOrder(Order order);
        public Task<List<Order>> GetOrdersByCustomer(string customerId);
    }
}
