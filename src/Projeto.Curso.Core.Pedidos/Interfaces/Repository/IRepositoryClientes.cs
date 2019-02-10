using Projeto.Curso.Core.Domain.Pedido.Entidades;

namespace Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository
{
    public interface IRepositoryClientes : IRepository<Clientes>
    {
        Clientes ObterPorCpfCnpj(string cpfcnpj);
        Clientes ObterPorApelido(string apelido);
    }
}
