using FluentValidation;
using FluentValidation.Results;
using System;

namespace Cadastro.Cliente.Domain.Clientes
{
    public class ClienteCrmall : AbstractValidator<ClienteCrmall>
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public short Sexo { get; private set; }
        public virtual EnderecoCrMall Endereco { get; private set; }
        public int EnderecoId { get; private set; }

        public ValidationResult ValidationResult { get; protected set; }

        protected ClienteCrmall() { }

        public ClienteCrmall(string nome, DateTime dataDeNascimento, short sexo, EnderecoCrMall endereco)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            Endereco = endereco;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarSexo(short sexo)
        {
            Sexo = sexo;
        }

        public void AlterarDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
        }

        public bool Validar()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("É obrigatório informar o Nome do cliente.");

            RuleFor(p => p.DataDeNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage("É obrigatório informar a Data de Nascimento do cliente.");

            RuleFor(p => p.Sexo)
                .NotEmpty()
                .NotNull()
                .WithMessage("É obrigatório informar o Sexo do cliente.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}