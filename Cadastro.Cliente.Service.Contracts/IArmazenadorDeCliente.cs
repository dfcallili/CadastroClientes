using Cadastro.Ciente.Dto;
using System.Threading.Tasks;

namespace Cadastro.Cliente.Service.Contracts
{
    public interface IArmazenadorDeCliente
    {
        Task Armazenar(ClienteCrmallDto clienteCrmallDto);
    }
}