using Projeto.Curso.Core.Domain.Pedido.Entidades;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Services
{
    public interface IServiceProdutos : IDisposable
    {
        Produtos Adicionar(Produtos produto);
        Produtos Atualizar(Produtos produto);
        Produtos Remover(Produtos produto);
        IEnumerable<Produtos> ObterTodos();
        Produtos ObterPorId(int id);
        Produtos ObterPorNome(string nome);
        Produtos ObterPorApelido(string apelido);
    }
}
