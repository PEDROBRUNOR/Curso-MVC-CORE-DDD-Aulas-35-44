using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Shared.Entidades;
using System.Linq;

namespace Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos
{
    public class ItensPedidos : EntidadeBase
    {
        public int Qtd { get; set; }
        public int IdPedido { get; set; }
        public virtual Pedidos Pedido { get; set; }
        public int IdProduto { get; set; }
        public virtual Produtos Produto { get; set; }

        public override bool EstaConsistente()
        {
            QuantidadeDeveSerSuperiorAZero();
            ItemDePedidoDeveSerAssociadoAUmPedido();
            ProdudoDeveSerPreenchido();
            return !ListaErros.Any();
        }

        public bool EstaConsistente(bool pedido)
        {
            QuantidadeDeveSerSuperiorAZero();
            ProdudoDeveSerPreenchido();
            return !ListaErros.Any();
        }

        private void VerificarSePedidoEstaEntregue()
        {
            if (Pedido != null && Pedido.DataEntrega != null) ListaErros.Add("Não é possível alterar a lista de itens de pdidos entregues!");
        }

        private void QuantidadeDeveSerSuperiorAZero()
        {
            if (Qtd <= 0) ListaErros.Add("Quantidade deverá ser informada!");
        }

        private void ItemDePedidoDeveSerAssociadoAUmPedido()
        {
            if (IdPedido <= 0) ListaErros.Add("Numero do pedido inválido!");
        }

        private void ProdudoDeveSerPreenchido()
        {
            if (IdProduto <= 0) ListaErros.Add("Produto deve ser informado!");
        }



    }
}
