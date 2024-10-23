using Core.Models;

namespace Core.Repositories
{
    public interface ICustomerRepository
    {
        public Task<Customer?> GetCustomer(string customerId);

    }
}
