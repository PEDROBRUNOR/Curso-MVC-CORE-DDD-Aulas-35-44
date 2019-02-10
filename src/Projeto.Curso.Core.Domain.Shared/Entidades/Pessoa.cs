using Projeto.Curso.Core.Domain.Shared.ValueObjects;

namespace Projeto.Curso.Core.Domain.Shared.Entidades
{
    public abstract class Pessoa : EntidadeBase
    {
        public Pessoa()
        {
            CPFCNPJ = new CpfCnpjVO();
            Email = new EmailVO();
            Endereco = new EnderecoVO();
        }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public CpfCnpjVO CPFCNPJ { get; set; }
        public EmailVO Email { get; set; }
        public EnderecoVO Endereco { get; set; }


        protected void ApelidoDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Apelido)) ListaErros.Add("Apelido deve ser preenchido!");
        }

        protected void ApelidoDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Apelido) && Apelido.Trim().Length > tamanho) ListaErros.Add("O campo apelido deve ter no máximo " + tamanho + " caracteres!");
        }

        protected void NomeDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Nome)) ListaErros.Add("Nome deve ser preenchido!");
        }

        protected void NomeDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Nome) && Nome.Trim().Length > tamanho) ListaErros.Add("O campo nome deve ter no máximo " + tamanho + " caracteres!");
        }


        protected void CPFouCNPJDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(CPFCNPJ.Numero)) ListaErros.Add("CPF ou CNPJ deve ser preenchido!");
        }

        protected void CPFouCNPJDeveSerValido()
        {
            if (!CPFCNPJ.Validar(CPFCNPJ.Numero)) ListaErros.Add("Digite um CPF ou CNPJ válido!");
        }

        protected void EmaiDeveSerValido()
        {
            if (!Email.Validar(Email.Endereco)) ListaErros.Add("Digite um e-mail válido");
        }

        protected void EmailDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Email.Endereco) && Email.Endereco.Trim().Length > tamanho) ListaErros.Add("O campo e-mail deve ter no máximo " + tamanho + " caracteres!");
        }

        protected void EnderecoDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Endereco.Logradouro)) ListaErros.Add("Endereco deve ser preenchido!");
        }

        protected void EnderecoDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Endereco.Logradouro) && Endereco.Logradouro.Trim().Length > tamanho) ListaErros.Add("O campo endereço deve ter no máximo " + tamanho + " caracteres!");
        }

        protected void BairroDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Endereco.Bairro) && Endereco.Bairro.Trim().Length > tamanho) ListaErros.Add("O campo bairro deve ter no máximo " + tamanho + " caracteres!");
        }

        protected void CidadeDeveSerPreenchida()
        {
            if (string.IsNullOrEmpty(Endereco.Cidade)) ListaErros.Add("Cidade deve ser preenchida!");
        }

        protected void CidadeDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Endereco.Cidade) && Endereco.Cidade.Trim().Length > tamanho) ListaErros.Add("O campo cidade deve ter no máximo " + tamanho + " caracteres!");
        }

        protected void UFDeveSerPreenchida()
        {
            if (string.IsNullOrEmpty(Endereco.UF.UF)) ListaErros.Add("UF deve ser preenchida!");
        }

        protected void UFDeveSerValida()
        {
            if (!Endereco.UF.Validar(Endereco.UF.UF)) ListaErros.Add("Digite uma UF Válida!");
        }

        protected void CepDeveSerValido()
        {
            if (!Endereco.CEP.Validar(Endereco.CEP.Codigo)) ListaErros.Add("Digite um CEP inválido!");
        }

    }
}
