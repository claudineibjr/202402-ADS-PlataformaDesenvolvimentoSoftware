using Core.Models;

namespace Core.Repositories
{
    public interface IAuthRepository
    {

        public Task<Customer?> GetCustomerByEmailAndPassword(string email, string password);

    }
}
