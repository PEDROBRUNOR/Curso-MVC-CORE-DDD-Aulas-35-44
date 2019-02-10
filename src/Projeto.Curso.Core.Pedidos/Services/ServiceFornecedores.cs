using System.Collections.Generic;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using System;
using System.Linq;

namespace Projeto.Curso.Core.Domain.Pedido.Services
{
    public class ServiceFornecedores : IServiceFornecedores
    {
        private readonly IRepositoryFornecedores repofornecedor;
        private readonly IServiceProdutos serviceproduto;

        public ServiceFornecedores(IRepositoryFornecedores _repofornecedor,
                                   IServiceProdutos _serviceproduto)
        {
            repofornecedor = _repofornecedor;
            serviceproduto = _serviceproduto;
        }

        #region Adicionar fornecedores

        public Fornecedores Adicionar(Fornecedores fornecedor)
        {
            fornecedor = AptoParaAdicionarFornecedores(fornecedor);
            if (fornecedor.ListaErros.Any()) return fornecedor;
            repofornecedor.Adicionar(fornecedor);
            return fornecedor;
        }

        private Fornecedores AptoParaAdicionarFornecedores(Fornecedores fornecedor)
        {
            if (!fornecedor.EstaConsistente()) return fornecedor;
            fornecedor = VerificarSeApelidoExisteEmInclusao(fornecedor);
            fornecedor = VerificarSeCPFCNPJExisteEmInclusao(fornecedor);
            return fornecedor;
        }


        private Fornecedores VerificarSeApelidoExisteEmInclusao(Fornecedores fornecedor)
        {
            if (ObterPorApelido(fornecedor.Apelido) != null) fornecedor.ListaErros.Add("O Apelido " + fornecedor.Apelido + " já existe em outro fornecedor!");
            return fornecedor;
        }

        private Fornecedores VerificarSeCPFCNPJExisteEmInclusao(Fornecedores fornecedor)
        {
            if (ObterPorCpfCnpj(fornecedor.CPFCNPJ.Numero) != null) fornecedor.ListaErros.Add("O CPF ou CNPJ " + fornecedor.CPFCNPJ.Numero + " já existe em outro fornecedor!");
            return fornecedor;
        }


        #endregion Adicionar fornecedores

        #region Atualizar fornecedores

        public Fornecedores Atualizar(Fornecedores fornecedor)
        {
            fornecedor = AptoParaAlterarFornecedores(fornecedor);
            if (fornecedor.ListaErros.Any()) return fornecedor;
            repofornecedor.Atualizar(fornecedor);
            return fornecedor;
        }

        private Fornecedores AptoParaAlterarFornecedores(Fornecedores fornecedor)
        {
            if (!fornecedor.EstaConsistente()) return fornecedor;
            fornecedor = VerificarSeApelidoExisteEmAlteracao(fornecedor);
            fornecedor = VerificarSeCPFCNPJExisteEmAlteracao(fornecedor);
            return fornecedor;
        }


        private Fornecedores VerificarSeApelidoExisteEmAlteracao(Fornecedores fornecedor)
        {
            var result = ObterPorApelido(fornecedor.Apelido);
            if (result != null && result.Id != fornecedor.Id) fornecedor.ListaErros.Add("O Apelido " + fornecedor.Apelido + " já existe em outro fornecedor!");
            return fornecedor;
        }

        private Fornecedores VerificarSeCPFCNPJExisteEmAlteracao(Fornecedores fornecedor)
        {
            var result = ObterPorCpfCnpj(fornecedor.CPFCNPJ.Numero);
            if (result != null && result.Id != fornecedor.Id) fornecedor.ListaErros.Add("O CPF ou CNPJ " + fornecedor.CPFCNPJ.Numero + " já existe em outro fornecedor!");
            return fornecedor;
        }


        #endregion Atualizar fornecedores

        #region Remover fornecedores


        public Fornecedores Remover(Fornecedores fornecedor)
        {
            fornecedor = VerificarSeExiteProdutoAssociadoAoFornecedor(fornecedor);
            if (fornecedor.ListaErros.Any()) return fornecedor;
            repofornecedor.Remover(fornecedor);
            return fornecedor;
        }

        private Fornecedores VerificarSeExiteProdutoAssociadoAoFornecedor(Fornecedores fornecedor)
        {
            var result = serviceproduto.ObterTodos().FirstOrDefault(p => p.IdFornecedor == fornecedor.Id);
            if (result != null) fornecedor.ListaErros.Add("Existe(m) produto(s) associados a este fornecedor, exclusão não permtida!");
            return fornecedor;

        }

        #endregion Remover fornecedores

        #region consulta fornecedores
        public IEnumerable<Fornecedores> ObterTodos()
        {
            return repofornecedor.ObterTodos();
        }

        public Fornecedores ObterPorId(int id)
        {
            return repofornecedor.ObterPorId(id);
        }

        public Fornecedores ObterPorApelido(string apelido)
        {
            return repofornecedor.ObterPorApelido(apelido);
        }

        public Fornecedores ObterPorCpfCnpj(string cpfcnpj)
        {
            return repofornecedor.ObterPorCpfCnpj(cpfcnpj);
        }

        #endregion consulta fornecedores

        public void Dispose()
        {
            repofornecedor.Dispose();
            serviceproduto.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
