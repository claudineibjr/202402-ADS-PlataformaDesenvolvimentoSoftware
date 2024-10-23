using Core.Services;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        public void SendSMS(string to, string body)
        {
            Console.WriteLine("SMS sendo enviado");
        }
    }
}
