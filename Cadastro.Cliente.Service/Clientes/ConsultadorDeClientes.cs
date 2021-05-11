using Cadastro.Ciente.Dto;
using Cadastro.Cliente.Infra.Data.Context;
using Cadastro.Cliente.Service.Base;
using Cadastro.Cliente.Service.Contracts;
using Cadastro.Cliente.Service.Contracts.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Cliente.Service.Clientes
{
    public class ConsultadorDeClientes : BaseService, IConsultadorDeClientes
    {
        private readonly CadastroClienteDbContext _context;

        public ConsultadorDeClientes(IDomainNotificationHandler notificacaoDeDominio,
            CadastroClienteDbContext context)
            : base(notificacaoDeDominio)
        {
            _context = context;
        }

        public async Task<List<ClienteCrmallDto>> Consultar()
        {
            var clientes = await _context.Clientes.Select(t => new ClienteCrmallDto()
            {
                Id = t.Id,
                Nome = t.Nome,
                DataDeNascimento = t.DataDeNascimento,
                Sexo = t.Sexo,
                Endereco = new EnderecoCrMallDto()
                {
                    Id = t.Endereco.Id,
                    Bairro = t.Endereco.Bairro,
                    Cep = t.Endereco.Cep,
                    Logradouro = t.Endereco.Logradouro,
                    Complemento = t.Endereco.Complemento,
                    Uf = t.Endereco.Uf,
                    Localidade = t.Endereco.Localidade,
                    Numero = t.Endereco.Numero
                }
            }).ToListAsync();

            return clientes;
        }

        public async Task<ClienteCrmallDto> Consultar(int clienteId)
        {
            var cliente = await _context.Clientes
                .Where(t => t.Id == clienteId)
                .Select(t => new ClienteCrmallDto()
            {
                Id = t.Id,
                Nome = t.Nome,
                DataDeNascimento = t.DataDeNascimento,
                Sexo = t.Sexo,
                Endereco = new EnderecoCrMallDto()
                {
                    Id = t.Endereco.Id,
                    Bairro = t.Endereco.Bairro,
                    Cep = t.Endereco.Cep,
                    Logradouro = t.Endereco.Logradouro,
                    Complemento = t.Endereco.Complemento,
                    Uf = t.Endereco.Uf,
                    Localidade = t.Endereco.Localidade,
                    Numero = t.Endereco.Numero
                }
            }).FirstOrDefaultAsync();

            return cliente;
        }
    }
}