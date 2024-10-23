using Core.Models;

namespace Core.Services
{
    public interface ITokenService
    {

        public string CreateCustomerToken(Customer customer);

    }
}
