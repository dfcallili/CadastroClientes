using System.Threading.Tasks;

namespace Cadastro.Cliente.Service.Contracts
{
    public interface IRemovedorDeCliente
    {
        Task Remover(int clienteId);
    }
}