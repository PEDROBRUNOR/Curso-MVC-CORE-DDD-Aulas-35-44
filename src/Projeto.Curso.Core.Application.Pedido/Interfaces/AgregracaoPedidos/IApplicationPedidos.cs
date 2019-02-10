using Projeto.Curso.Core.Application.Pedido.ViewModels.AgregracaoPedidos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedido.Interfaces.AgregracaoPedidos
{
    public interface IApplicationPedidos : IDisposable
    {
        PedidosViewModel Adicionar(PedidosViewModel pedido);
        PedidosViewModel Atualizar(PedidosViewModel pedido);
        PedidosViewModel Remover(PedidosViewModel pedido);
        IEnumerable<PedidosViewModel> ObterTodos();
        PedidosViewModel ObterPorId(int id);
        PedidosViewModel ObterPedidoCompleto(int id);
        IEnumerable<PedidosViewModel> ObterListagemPedidos();
    }
}
