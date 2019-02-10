using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos
{
    public interface IServiceItensPedidos : IDisposable
    {
        ItensPedidos AdicionarItensPedidos(ItensPedidos item);
        ItensPedidos AtulizarItensPedidos(ItensPedidos item);
        ItensPedidos RemoverItensPedidos(ItensPedidos item);
        ItensPedidos ObterItensPedidosPorId(int id);
        IEnumerable<ItensPedidos> ObterItensPedido(int idpedido);
        IEnumerable<ItensPedidos> ObterItensPedidoProdutoEspecifico(int idproduto);
    }
}
