using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.DTO;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos
{
    public interface IRepositoryPedidos : IRepository<Pedidos>
    {
        void AdicionarItensPedidos(ItensPedidos item);
        void AtulizarItensPedidos(ItensPedidos item);
        void RemoverItensPedidos(ItensPedidos item);
        ItensPedidos ObterItensPedidosPorId(int id);
        IEnumerable<ItensPedidos> ObterItensPedido(int idpedido);
        IEnumerable<ItensPedidos> ObterItensPedidoProdutoEspecifico(int idproduto);
        PedidoDTO ObterPorIdCompleto(int id);
        IEnumerable<PedidoDTO> ObterListagemPedidos();
    }
}
