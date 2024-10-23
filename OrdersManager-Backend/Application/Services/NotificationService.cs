using Core.Models;
using Core.Services;

namespace Application.Services
{
    enum NotificationTypeEnum
    {
        EMAIL,
        SMS
    }

    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;
        private readonly IMessageService _messageService;

        public NotificationService(IEmailService emailService, IMessageService messageService)
        {
            _emailService = emailService;
            _messageService = messageService;
        }

        private List<NotificationTypeEnum> ValidateOrderAndGetNotificationTypes(Order order)
        {
            List<NotificationTypeEnum> notificationTypes = new List<NotificationTypeEnum>();

            if (!String.IsNullOrEmpty(order.Customer.Email))
            {
                notificationTypes.Add(NotificationTypeEnum.EMAIL);
            }

            if (!String.IsNullOrEmpty(order.Customer.PhoneNumber))
            {
                notificationTypes.Add(NotificationTypeEnum.SMS);
            }

            if (notificationTypes.Count == 0)
            {
                throw new Exception("Cliente inválido, precisa haver e-mail ou telefone");
            }

            return notificationTypes;
        }

        public void SendNotification(Order order)
        {
            List<NotificationTypeEnum> notificationTypes = ValidateOrderAndGetNotificationTypes(order);

            notificationTypes.ForEach(notificationType => {
                switch (notificationType)
                {
                    case NotificationTypeEnum.EMAIL:
                        _emailService.SendEmail(order.Customer.Email, "Pedido criado", "Parabéns, seu pedido foi criado com sucesso");
                        break;

                    case NotificationTypeEnum.SMS:
                        _messageService.SendSMS(order.Customer.PhoneNumber, "Parabéns, seu pedido foi criado");
                        break;
                }
            });
        }
    }
}
