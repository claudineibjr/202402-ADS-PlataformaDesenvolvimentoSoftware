using Core.Models;

namespace Core.Services
{
    public interface ICustomerService
    {
        public Task<Customer> GetCustomerOrThrowException(string customerId);
    }
}
