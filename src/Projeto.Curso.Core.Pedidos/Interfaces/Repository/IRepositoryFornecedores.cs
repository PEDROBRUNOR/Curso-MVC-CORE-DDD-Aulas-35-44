using Projeto.Curso.Core.Domain.Pedido.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository
{
    public interface IRepositoryFornecedores : IRepository<Fornecedores>
    {
        Fornecedores ObterPorCpfCnpj(string cpfcnpj);
        Fornecedores ObterPorApelido(string apelido);
    }
}
