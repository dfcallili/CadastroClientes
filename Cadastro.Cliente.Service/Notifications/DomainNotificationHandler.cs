using Cadastro.Cliente.Service.Contracts.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Cliente.Service.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private List<string> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<string>();
        }

        public void Handle(string message)
        {
            _notifications.Add(message);
        }

        public List<string> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Clean()
        {
            _notifications = new List<string>();
        }

        public void Dispose()
        {
            Clean();
        }
    }
}