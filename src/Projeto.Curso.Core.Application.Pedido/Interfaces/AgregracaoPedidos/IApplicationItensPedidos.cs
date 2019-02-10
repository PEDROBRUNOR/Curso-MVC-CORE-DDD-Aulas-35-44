using Projeto.Curso.Core.Application.Pedido.ViewModels.AgregracaoPedidos;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Interfaces.AgregracaoPedidos
{
    public interface IApplicationItensPedidos : IDisposable
    {
        ItensPedidosViewModel AdicionarItensPedidos(ItensPedidosViewModel item);
        ItensPedidosViewModel AtulizarItensPedidos(ItensPedidosViewModel item);
        ItensPedidosViewModel RemoverItensPedidos(ItensPedidosViewModel item);
        ItensPedidosViewModel ObterItensPedidosPorId(int id);
        IEnumerable<ItensPedidosViewModel> ObterItensPedido(int idpedido);
        IEnumerable<ItensPedidosViewModel> ObterItensPedidoProdutoEspecifico(int idproduto);
    }
}
