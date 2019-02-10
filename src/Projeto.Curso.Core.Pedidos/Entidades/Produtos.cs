using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Curso.Core.Domain.Pedido.Entidades
{
    public class Produtos : EntidadeBase
    {
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public byte[] Foto { get; set; }
        public int IdFornecedor { get; set; }
        public virtual Fornecedores Fornecedor { get; set; }
        public virtual ICollection<ItensPedidos> ItensPedidos { get; set; }


        public override bool EstaConsistente()
        {
            ApelidoDeveSerPreenchido();
            ApelidoDeveTerUmTamanhoLimite();
            NomeDeveSerPreenchido();
            NomeDeveTerUmTamanhoLimite();
            ValorDeverSerSuperiorAZero();
            UnidadeDeveSerValida();
            FornecedorDeveSerPreenchido();
            return !ListaErros.Any();
        }

        private void ApelidoDeveSerPreenchido()
        {
            if(string.IsNullOrEmpty(Apelido))  ListaErros.Add("O campo apelido deve ser preenchido!");  
        }

        private void ApelidoDeveTerUmTamanhoLimite()
        {
            if (Apelido.Length > 20) ListaErros.Add("O campo apelido deve ter no máximo 20 caracteres!");
        }

        private void NomeDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Nome)) ListaErros.Add("O campo nome deve ser preenchido!");
        }

        private void NomeDeveTerUmTamanhoLimite()
        {
            if (Nome.Length > 150) ListaErros.Add("O campo nome deve ter no máximo 150 caracteres!");
        }


        private void ValorDeverSerSuperiorAZero()
        {
            if (Valor <= 0) ListaErros.Add("O campo valor dever ser maior que zero!");
        }


        private void UnidadeDeveSerValida()
        {
            var listunidade = new List<string> { "CM", "G", "KG", "M", "UN" };
            if (!listunidade.Contains(Unidade)) ListaErros.Add("Unidade deve ser CM, G, KG, M ou UN!");
        }

        private void FornecedorDeveSerPreenchido()
        {
            if (IdFornecedor == 0) ListaErros.Add("O campo fornecedor dever informado!");
        }

    }
}
