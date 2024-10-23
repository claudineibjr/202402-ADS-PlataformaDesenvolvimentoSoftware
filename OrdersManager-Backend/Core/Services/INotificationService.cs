using Core.Models;

namespace Core.Services
{
    public interface INotificationService
    {
        public void SendNotification(Order order);
    }
}
