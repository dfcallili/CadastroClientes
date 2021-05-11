namespace Cadastro.Cliente.Domain.Clientes
{
    public class EnderecoCrMall
    {
        public int Id { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public short Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Uf { get; private set; }
        public string Localidade { get; private set; }

        protected EnderecoCrMall() { }

        public EnderecoCrMall(string cep, string logradouro, short numero,
            string complemento, string bairro, string estado, string localidade)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Uf = estado;
            Localidade = localidade;
        }

        public void AlterarCep(string cep)
        {
            Cep = cep;
        }

        public void AlterarLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }

        public void AlterarNumero(short numero)
        {
            Numero = numero;
        }

        public void AlterarComplemento(string complemento)
        {
            Complemento = complemento;
        }

        public void AlterarUf(string uf)
        {
            Uf = uf;
        }

        public void AlterarLocalidade(string localidade)
        {
            Localidade = localidade;
        }

        public void AlterarBairro(string bairro)
        {
            Bairro = bairro;
        }
    }
}