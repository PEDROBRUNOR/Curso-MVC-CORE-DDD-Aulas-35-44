using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.ViewModels.AgregracaoPedidos
{
    public class ItensPedidosViewModel
    {
        public ItensPedidosViewModel()
        {
            ListaErros = new List<string>();
        }
        public int Id { get; set; }
        public List<string> ListaErros { get; set; }
        public int Qtd { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

    }
}
