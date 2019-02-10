using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Curso.Core.Domain.Pedido.Services.AgregacaoPedidos
{
    public class ServiceItensPedidos : IServiceItensPedidos
    {
        private readonly IRepositoryPedidos repopedidos;

        public ServiceItensPedidos(IRepositoryPedidos _repopedidos)
        {
            repopedidos = _repopedidos;
        }

        #region Adicionar itens
        public ItensPedidos AdicionarItensPedidos(ItensPedidos item)
        {
            item = AptoParaAdicionarItens(item);
            if (item.ListaErros.Any()) return item;
            repopedidos.AdicionarItensPedidos(item);
            return item;
        }

        private ItensPedidos AptoParaAdicionarItens(ItensPedidos item)
        {
            if (!item.EstaConsistente()) return item;
            item = VerificarSeProdutoJaExisteNoPedidoInclusao(item);
            return item;
        }


        private ItensPedidos VerificarSeProdutoJaExisteNoPedidoInclusao(ItensPedidos item)
        {
            var itens = ObterItensPedidoProdutoEspecifico(item.IdProduto).FirstOrDefault(x => x.IdPedido == item.IdPedido);
            if (itens != null) item.ListaErros.Add("Este produto já existe neste pedido!");
            return item;
        }


        #endregion adcionar itens

        #region Atualizar itens
        public ItensPedidos AtulizarItensPedidos(ItensPedidos item)
        {
            item = AptoParaAtualizarItens(item);
            if (item.ListaErros.Any()) return item;
            repopedidos.AtulizarItensPedidos(item);
            return item;
        }

        private ItensPedidos AptoParaAtualizarItens(ItensPedidos item)
        {
            if (!item.EstaConsistente()) return item;
            item = VerificarSeProdutoJaExisteNoPedidoAlteracao(item);
            return item;
        }

        private ItensPedidos VerificarSeProdutoJaExisteNoPedidoAlteracao(ItensPedidos item)
        {
            var itens = ObterItensPedidoProdutoEspecifico(item.IdProduto).FirstOrDefault(x => x.IdPedido == item.IdPedido && x.Id != item.Id);
            if (itens != null) item.ListaErros.Add("Este produto já existe neste pedido!");
            return item;
        }


        #endregion atualizar itens

        #region Remover itens
        public ItensPedidos RemoverItensPedidos(ItensPedidos item)
        {
            var pedido = new Pedidos();
            pedido = pedido.VerificarSePedidoJaFoiEntregue(item.Pedido);
            if (!pedido.ListaErros.Any())
            {
                var itens = ObterItensPedido(item.IdPedido).ToList();
                if (itens.Count() > 1)
                {
                    repopedidos.RemoverItensPedidos(item);
                }
                else
                {
                    pedido = repopedidos.ObterPorId(item.IdPedido);
                    repopedidos.Remover(pedido);
                }
            }
            else
            {
                item.ListaErros.Add(pedido.ListaErros[0]);
            }
            return item;
        }

        #endregion remover itens

        #region Consultar itens

        public IEnumerable<ItensPedidos> ObterItensPedido(int idpedido)
        {
            return repopedidos.ObterItensPedido(idpedido);
        }


        public ItensPedidos ObterItensPedidosPorId(int id)
        {
            return repopedidos.ObterItensPedidosPorId(id);
        }
        public IEnumerable<ItensPedidos> ObterItensPedidoProdutoEspecifico(int idproduto)
        {
            return repopedidos.ObterItensPedidoProdutoEspecifico(idproduto);
        }

        #endregion consultar itens

        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
