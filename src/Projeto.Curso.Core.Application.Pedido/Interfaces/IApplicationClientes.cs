using Projeto.Curso.Core.Application.Pedido.ViewModels;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Interfaces
{
    public interface IApplicationClientes : IDisposable
    {
        ClientesViewModel Adicionar(ClientesViewModel cliente);
        ClientesViewModel Atualizar(ClientesViewModel cliente);
        ClientesViewModel Remover(ClientesViewModel cliente);
        IEnumerable<ClientesViewModel> ObterTodos();
        ClientesViewModel ObterPorId(int id);
        ClientesViewModel ObterPorCpfCnpj(string cpfcnpj);
        ClientesViewModel ObterPorApelido(string apelido);

    }
}
