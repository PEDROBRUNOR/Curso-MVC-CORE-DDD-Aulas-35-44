using Projeto.Curso.Core.Application.Pedido.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedido.Interfaces
{
    public interface IApplicationFornecedores : IDisposable
    {
        FornecedoresViewModel Adicionar(FornecedoresViewModel fornecedor);
        FornecedoresViewModel Atualizar(FornecedoresViewModel fornecedor);
        FornecedoresViewModel Remover(FornecedoresViewModel fornecedor);
        IEnumerable<FornecedoresViewModel> ObterTodos();
        FornecedoresViewModel ObterPorId(int id);
        FornecedoresViewModel ObterPorCpfCnpj(string cpfcnpj);
        FornecedoresViewModel ObterPorApelido(string apelido);

    }
}
