using Projeto.Curso.Core.Domain.Pedido.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Services
{
    public interface IServiceClientes : IDisposable
    {
        Clientes Adicionar(Clientes cliente);
        Clientes Atualizar(Clientes cliente);
        Clientes Remover(Clientes cliente);
        IEnumerable<Clientes> ObterTodos();
        Clientes ObterPorId(int id);
        Clientes ObterPorCpfCnpj(string cpfcnpj);
        Clientes ObterPorApelido(string apelido);
    }
}
