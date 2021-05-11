namespace Cadastro.Ciente.Dto
{
    public class EnderecoCrMallDto
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public short Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }
    }
}