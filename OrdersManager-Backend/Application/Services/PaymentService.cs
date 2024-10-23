using Core.Models;
using Core.Services;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        public void RequestPayment(Order order)
        {
            Console.WriteLine("Pagamento processado para o pedido");

            if (order.TotalAmount >= 10000)
            {
                throw new Exception("Pagamento recusado. Um pedido não pode custar mais de R$ 10.000,00");
            }

            Console.WriteLine("Pagamento processado com sucesso");
        }
    }
}
