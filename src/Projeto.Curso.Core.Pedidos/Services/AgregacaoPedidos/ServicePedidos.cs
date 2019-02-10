using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.DTO;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;

namespace Projeto.Curso.Core.Domain.Pedido.Services.AgregacaoPedidos
{
    public class ServicePedidos : IServicePedidos
    {
        protected readonly IRepositoryPedidos repopedidos;

        public ServicePedidos(IRepositoryPedidos _repopedidos)
        {
            repopedidos = _repopedidos;
        }

        #region adicionar pedidos

        public Pedidos Adicionar(Pedidos pedido)
        {
            pedido = AptoParaAdicionarPedidos(pedido);
            if (pedido.ListaErros.Any()) return pedido;
            repopedidos.Adicionar(pedido);
            return pedido;
        }

        private Pedidos AptoParaAdicionarPedidos(Pedidos pedido)
        {
            if (!pedido.EstaConsistente()) return pedido;
            pedido = VerificarSeExistePedidoAbertoDoClienteNaDataInclusao(pedido);
            pedido = VerificarSeExisteItemDePedidoNaInclusao(pedido);
            pedido = VerificarSeItemPedidoDaInclusaoEhConsistente(pedido);
            return pedido;
        }

        private Pedidos VerificarSeExistePedidoAbertoDoClienteNaDataInclusao(Pedidos pedido)
        {
            var pedidos = ObterTodos().FirstOrDefault(x => x.IdCliente == pedido.IdCliente && x.DataEntrega == null && x.DataPedido == pedido.DataPedido);
            if (pedidos != null) pedido.ListaErros.Add("Existe(m) pedido(s) abertos deste cliente nesta data " + pedido.DataPedido.ToString("dd/MM/yyyy") + "!");
            return pedido;
        }

        private Pedidos VerificarSeExisteItemDePedidoNaInclusao(Pedidos pedido)
        {
            if (pedido.ItensPedidos.Count() != 1) pedido.ListaErros.Add("Na inclusão do pedido é preciso informar somente um item!");
            return pedido;
        }

        private Pedidos VerificarSeItemPedidoDaInclusaoEhConsistente(Pedidos pedido)
        {
            if (pedido.ItensPedidos.Count() == 1)
            {
                var item = pedido.ItensPedidos.ToList()[0];
                if (!item.EstaConsistente(true))
                {
                    foreach (var erros in item.ListaErros)
                    {
                        pedido.ListaErros.Add(erros);
                    }
                }
            }
            return pedido;
        }



        #endregion adcionar pedidos

        #region atualizar pedidos

        public Pedidos Atualizar(Pedidos pedido)
        {
            pedido = AptoParaAtualizarPedidos(pedido);
            if (pedido.ListaErros.Any()) return pedido;
            repopedidos.Atualizar(pedido);
            return pedido;
        }

        private Pedidos AptoParaAtualizarPedidos(Pedidos pedido)
        {
            if (!pedido.EstaConsistente()) return pedido;
            pedido = VerificarSeExistePedidoAbertoDoClienteNaDataAlteracao(pedido);
            pedido = pedido.VerificarSePedidoJaFoiEntregue(pedido);
            return pedido;
        }

        private Pedidos VerificarSeExistePedidoAbertoDoClienteNaDataAlteracao(Pedidos pedido)
        {
            var pedidos = ObterTodos().FirstOrDefault(x => x.IdCliente == pedido.IdCliente && x.DataEntrega == null && x.DataPedido == pedido.DataPedido && x.Id != pedido.Id);
            if (pedidos != null) pedido.ListaErros.Add("Existe(m) pedido(s) abertos deste cliente nesta data " + pedido.DataPedido.ToString("dd/MM/yyyy") + "!");
            return pedido;
        }


        #endregion atualizar pedido

        #region remover pedido
        public Pedidos Remover(Pedidos pedido)
        {
            pedido = pedido.VerificarSePedidoJaFoiEntregue(pedido);
            if (pedido.ListaErros.Any()) return pedido;
            repopedidos.Remover(pedido);
            return pedido;
        }

        #endregion remover pedido

        #region consulta pedidos
        public IEnumerable<Pedidos> ObterTodos()
        {
            return repopedidos.ObterTodos();
        }


        public Pedidos ObterPorId(int id)
        {
            return repopedidos.ObterPorId(id);
        }

        public PedidoDTO ObterPedidoCompleto(int id)
        {
            return repopedidos.ObterPorIdCompleto(id);
        }

        public IEnumerable<PedidoDTO> ObterListagemPedidos()
        {
            return repopedidos.ObterListagemPedidos();
        }


        #endregion consulta pedidos

        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
