using System.Collections.Generic;

namespace Cadastro.Cliente.Service.Contracts.Notifications
{
    public interface IDomainNotificationHandler
    {
        void Handle(string message);
        bool HasNotifications();
        List<string> GetNotifications();
        void Clean();
    }
}