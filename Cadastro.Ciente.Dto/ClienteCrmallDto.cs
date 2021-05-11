using System;

namespace Cadastro.Ciente.Dto
{
    public class ClienteCrmallDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string DataDeNascimentoString => DataDeNascimento.ToString("dd/MM/yyyy");
        public short Sexo { get; set; }
        public virtual EnderecoCrMallDto Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}