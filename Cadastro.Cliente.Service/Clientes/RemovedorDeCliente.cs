using Cadastro.Cliente.Infra.Data.Context;
using Cadastro.Cliente.Service.Base;
using Cadastro.Cliente.Service.Contracts;
using Cadastro.Cliente.Service.Contracts.Notifications;
using System;
using System.Threading.Tasks;

namespace Cadastro.Cliente.Service.Clientes
{
    public class RemovedorDeCliente : BaseService, IRemovedorDeCliente
    {
        private readonly CadastroClienteDbContext _context;

        public RemovedorDeCliente(IDomainNotificationHandler notificacaoDeDominio,
            CadastroClienteDbContext context)
            : base(notificacaoDeDominio)
        {
            _context = context;
        }

        public async Task Remover(int clienteId)
        {
            var clienteARemover = await _context.Clientes.FindAsync(clienteId);

            if(clienteARemover == null)
                throw new Exception("Cliente a remover não existe na base.");

            _context.Clientes.Remove(clienteARemover);
            await _context.SaveChangesAsync();
        }
    }
}
