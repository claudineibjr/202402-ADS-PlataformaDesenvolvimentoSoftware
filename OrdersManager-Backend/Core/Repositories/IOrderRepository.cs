using Core.Models;

namespace Core.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> SaveOrder(Order order);
    }
}
