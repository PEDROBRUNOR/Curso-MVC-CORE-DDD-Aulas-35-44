using Projeto.Curso.Core.Application.Pedido.ViewModels;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Interfaces
{
    public interface IApplicationProdutos : IDisposable
    {
        ProdutosViewModel Adicionar(ProdutosViewModel produto);
        ProdutosViewModel Atualizar(ProdutosViewModel produto);
        ProdutosViewModel Remover(ProdutosViewModel produto);
        IEnumerable<ProdutosViewModel> ObterTodos();
        ProdutosViewModel ObterPorId(int id);
        ProdutosViewModel ObterPorNome(string nome);
        ProdutosViewModel ObterPorApelido(string apelido);

    }
}
