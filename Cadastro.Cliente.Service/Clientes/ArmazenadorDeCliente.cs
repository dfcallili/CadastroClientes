using Cadastro.Ciente.Dto;
using Cadastro.Cliente.Domain.Clientes;
using Cadastro.Cliente.Infra.Data.Context;
using Cadastro.Cliente.Service.Base;
using Cadastro.Cliente.Service.Contracts;
using Cadastro.Cliente.Service.Contracts.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Cliente.Service.Clientes
{
    public class ArmazenadorDeCliente : BaseService, IArmazenadorDeCliente
    {
        private readonly CadastroClienteDbContext _context;

        public ArmazenadorDeCliente(IDomainNotificationHandler notificacaoDeDominio,
            CadastroClienteDbContext context)
            : base(notificacaoDeDominio)
        {
            _context = context;
        }

        public async Task Armazenar(ClienteCrmallDto clienteCrmallDto)
        {
            if (clienteCrmallDto == null)
                throw new Exception("Informe os dados do Cliente a ser adicionado.");

            if (clienteCrmallDto.Endereco == null)
                throw new Exception("Informe o Endereço do Cliente.");

            ClienteCrmall cliente = null;

            if (clienteCrmallDto.Id == 0)
            {
                var endereco = new EnderecoCrMall(clienteCrmallDto.Endereco.Cep,
                    clienteCrmallDto.Endereco.Logradouro, clienteCrmallDto.Endereco.Numero,
                    clienteCrmallDto.Endereco.Complemento,
                    clienteCrmallDto.Endereco.Bairro, clienteCrmallDto.Endereco.Uf,
                    clienteCrmallDto.Endereco.Logradouro);

                cliente = new ClienteCrmall(clienteCrmallDto.Nome,
                    clienteCrmallDto.DataDeNascimento,
                    clienteCrmallDto.Sexo,
                    endereco);
            }
            else
            {
                cliente = await AlterarCliente(clienteCrmallDto);
            }


            if (!cliente.Validar())
            {
                NotificarValidacoesDeDominio(cliente.ValidationResult);
                return;
            }

            if (cliente.Id == 0)
                _context.Clientes.Add(cliente);
            else
                _context.Clientes.Update(cliente);

            await _context.SaveChangesAsync();
            clienteCrmallDto.Id = cliente.Id;
        }

        private async Task<ClienteCrmall> AlterarCliente(ClienteCrmallDto clienteCrmallDto)
        {
            var clienteAlterado = await _context.Clientes.Where(t => t.Id == clienteCrmallDto.Id)
                .Include(t => t.Endereco)
                .FirstOrDefaultAsync();

            clienteAlterado.AlterarNome(clienteCrmallDto.Nome);
            clienteAlterado.AlterarSexo(clienteCrmallDto.Sexo);
            clienteAlterado.AlterarDataDeNascimento(clienteCrmallDto.DataDeNascimento);
            clienteAlterado.Endereco.AlterarCep(clienteCrmallDto.Endereco.Cep);
            clienteAlterado.Endereco.AlterarComplemento(clienteCrmallDto.Endereco.Complemento);
            clienteAlterado.Endereco.AlterarLocalidade(clienteCrmallDto.Endereco.Localidade);
            clienteAlterado.Endereco.AlterarLogradouro(clienteCrmallDto.Endereco.Logradouro);
            clienteAlterado.Endereco.AlterarNumero(clienteCrmallDto.Endereco.Numero);
            clienteAlterado.Endereco.AlterarUf(clienteCrmallDto.Endereco.Uf);
            clienteAlterado.Endereco.AlterarBairro(clienteCrmallDto.Endereco.Bairro);

            return clienteAlterado;
        }
    }
}