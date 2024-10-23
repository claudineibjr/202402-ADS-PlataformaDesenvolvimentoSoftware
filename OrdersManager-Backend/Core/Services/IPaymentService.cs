using Core.Models;

namespace Core.Services
{
    public interface IPaymentService
    {
        public void RequestPayment(Order order);
    }
}
