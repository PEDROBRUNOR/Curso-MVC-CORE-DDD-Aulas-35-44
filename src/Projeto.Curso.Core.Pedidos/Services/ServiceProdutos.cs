using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Curso.Core.Domain.Pedido.Services
{
    public class ServiceProdutos : IServiceProdutos
    {

        private readonly IRepositoryProdutos repoprodutos;
        private readonly IServiceItensPedidos serviceitenspedidos;

        public ServiceProdutos(IRepositoryProdutos _repoprodutos,
                               IServiceItensPedidos _serviceitenspedidos)
        {
            repoprodutos = _repoprodutos;
            serviceitenspedidos = _serviceitenspedidos;
        }

        #region Adicionar produtos

        public Produtos Adicionar(Produtos produto)
        {
            produto = AptoParaAdicionarProdutos(produto);
            if (produto.ListaErros.Any()) return produto;
            repoprodutos.Adicionar(produto);
            return produto;
        }

        private Produtos AptoParaAdicionarProdutos(Produtos produto)
        {
            if (!produto.EstaConsistente()) return produto;
            produto = VerificarSeApelidoExisteEmInclusao(produto);
            produto = VerificarSeNomeExisteEmInclusao(produto);
            return produto;
        }


        private Produtos VerificarSeApelidoExisteEmInclusao(Produtos produto)
        {
            if (ObterPorApelido(produto.Apelido) != null) produto.ListaErros.Add("O Apelido " + produto.Apelido + " já existe em outro produto!");
            return produto;
        }

        private Produtos VerificarSeNomeExisteEmInclusao(Produtos produto)
        {
            if (ObterPorNome(produto.Nome) != null) produto.ListaErros.Add("O Nome " + produto.Nome + " já existe em outro produto!");
            return produto;
        }

        #endregion Adicionar produtos

        #region Atualizar produtos
        public Produtos Atualizar(Produtos produto)
        {
            produto = AptoParaAlterarProdutos(produto);
            if (produto.ListaErros.Any()) return produto;
            repoprodutos.Atualizar(produto);
            return produto;
        }

        private Produtos AptoParaAlterarProdutos(Produtos produto)
        {
            if (!produto.EstaConsistente()) return produto;
            produto = VerificarSeApelidoExisteEmAlteracao(produto);
            produto = VerificarSeNomeExisteEmAlteracao(produto);
            return produto;
        }

        private Produtos VerificarSeApelidoExisteEmAlteracao(Produtos produto)
        {
            var result = ObterPorApelido(produto.Apelido);
            if (result != null && result.Id != produto.Id) produto.ListaErros.Add("O Apelido " + produto.Apelido + " já existe em outro produto!");
            return produto;
        }

        private Produtos VerificarSeNomeExisteEmAlteracao(Produtos produto)
        {
            var result = ObterPorNome(produto.Nome);
            if (result != null && result.Id != produto.Id) produto.ListaErros.Add("O Nome " + produto.Nome + " já existe em outro produto!");
            return produto;
        }


        #endregion Atualizar produtos

        #region Remover produtos
        public Produtos Remover(Produtos produto)
        {
            produto = VerificarSeExiteProdutoAssociadoAItensPedidos(produto);
            if (produto.ListaErros.Any()) return produto;
            repoprodutos.Remover(produto);
            return produto;
        }

        private Produtos VerificarSeExiteProdutoAssociadoAItensPedidos(Produtos produto)
        {
            var result = serviceitenspedidos.ObterItensPedidoProdutoEspecifico(produto.Id).FirstOrDefault();
            if (result != null) produto.ListaErros.Add("Existe(m) produto(s) associados a um pedido, exclusão não permtida!");
            return produto;
        }


        #endregion Remover produtos

        #region Consultar produtos
        public IEnumerable<Produtos> ObterTodos()
        {
            return repoprodutos.ObterTodos();
        }

        public Produtos ObterPorId(int id)
        {
            return repoprodutos.ObterPorId(id);
        }

        public Produtos ObterPorApelido(string apelido)
        {
            return repoprodutos.ObterPorApelido(apelido);
        }
        public Produtos ObterPorNome(string nome)
        {
            return repoprodutos.ObterPorNome(nome);
        }

        #endregion Consultar produtos

        public void Dispose()
        {
            repoprodutos.Dispose();
            serviceitenspedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
