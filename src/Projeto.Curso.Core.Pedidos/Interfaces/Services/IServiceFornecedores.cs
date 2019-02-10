using Projeto.Curso.Core.Domain.Pedido.Entidades;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Services
{
    public interface IServiceFornecedores : IDisposable
    {
        Fornecedores Adicionar(Fornecedores fornecedor);
        Fornecedores Atualizar(Fornecedores fornecedor);
        Fornecedores Remover(Fornecedores fornecedor);
        IEnumerable<Fornecedores> ObterTodos();
        Fornecedores ObterPorId(int id);
        Fornecedores ObterPorCpfCnpj(string cpfcnpj);
        Fornecedores ObterPorApelido(string apelido);

    }
}
