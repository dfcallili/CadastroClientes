using Cadastro.Cliente.Service.Contracts.Notifications;
using FluentValidation.Results;

namespace Cadastro.Cliente.Service.Base
{
    public class BaseService
    {
        protected readonly IDomainNotificationHandler _notificacaoDeDominio;

        public BaseService(IDomainNotificationHandler notificacaoDeDominio)
        {
            _notificacaoDeDominio = notificacaoDeDominio;
        }

        public void NotificarValidacoesDeDominio(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                _notificacaoDeDominio.Handle(erro.ErrorMessage);
            }
        }
    }
}