using Core.Services;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string email, string subject, string body)
        {
            Console.WriteLine("Email enviado");
        }
    }
}
