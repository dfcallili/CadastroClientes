using Cadastro.Ciente.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Cliente.Service.Contracts
{
    public interface IConsultadorDeClientes
    {
        Task<List<ClienteCrmallDto>> Consultar();
        Task<ClienteCrmallDto> Consultar(int clienteId);
    }
}
