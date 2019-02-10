using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Curso.Core.Domain.Pedido.Services
{
    public class ServiceClientes : IServiceClientes
    {
        private readonly IRepositoryClientes repoclientes;
        private readonly IServicePedidos servicepedidos;

        public ServiceClientes(IRepositoryClientes _repoclientes,
                               IServicePedidos _servicepedidos)
        {
            repoclientes = _repoclientes;
            servicepedidos = _servicepedidos;
        }

        #region Adicionar clientes
        public Clientes Adicionar(Clientes cliente)
        {
            cliente = AptoParaAdicionarClientes(cliente);
            if (cliente.ListaErros.Any()) return cliente;
            repoclientes.Adicionar(cliente);
            return cliente;
        }

        private Clientes AptoParaAdicionarClientes(Clientes cliente)
        {
            if (!cliente.EstaConsistente()) return cliente;
            cliente = VerificarSeApelidoExisteEmInclusao(cliente);
            cliente = VerificarSeCPFCNPJExisteEmInclusao(cliente);
            return cliente;
        }

        private Clientes VerificarSeApelidoExisteEmInclusao(Clientes cliente)
        {
            if (ObterPorApelido(cliente.Apelido) != null) cliente.ListaErros.Add("O Apelido " + cliente.Apelido + " já existe em outro cliente!");
            return cliente;
        }

        private Clientes VerificarSeCPFCNPJExisteEmInclusao(Clientes cliente)
        {
            if (ObterPorCpfCnpj(cliente.CPFCNPJ.Numero) != null) cliente.ListaErros.Add("O CPF ou CNPJ " + cliente.CPFCNPJ.Numero + " já existe em outro cliente!");
            return cliente;
        }


        #endregion Adcionar clientes

        #region Atualizar clientes
        public Clientes Atualizar(Clientes cliente)
        {
            cliente = AptoParaAlterarClientes(cliente);
            if (cliente.ListaErros.Any()) return cliente;
            repoclientes.Atualizar(cliente);
            return cliente;
        }

        private Clientes AptoParaAlterarClientes(Clientes cliente)
        {
            if (!cliente.EstaConsistente()) return cliente;
            cliente = VerificarSeApelidoExisteEmAlteracao(cliente);
            cliente = VerificarSeCPFCNPJExisteEmAlteracao(cliente);
            return cliente;
        }


        private Clientes VerificarSeApelidoExisteEmAlteracao(Clientes cliente)
        {
            var result = ObterPorApelido(cliente.Apelido);
            if (result != null && result.Id != cliente.Id ) cliente.ListaErros.Add("O Apelido " + cliente.Apelido + " já existe em outro cliente!");
            return cliente;
        }

        private Clientes VerificarSeCPFCNPJExisteEmAlteracao(Clientes cliente)
        {
            var result = ObterPorCpfCnpj(cliente.CPFCNPJ.Numero);
            if (result != null && result.Id != cliente.Id) cliente.ListaErros.Add("O CPF ou CNPJ " + cliente.CPFCNPJ.Numero + " já existe em outro cliente!");
            return cliente;
        }


        #endregion Atualizar clientes

        #region Remover clientes
        public Clientes Remover(Clientes cliente)
        {
            cliente = VerificarSeExistePedidoAssociadoAoCliente(cliente);
            if (cliente.ListaErros.Any()) return cliente;
            repoclientes.Remover(cliente);
            return cliente;
        }

        private Clientes VerificarSeExistePedidoAssociadoAoCliente(Clientes cliente)
        {
            var result = servicepedidos.ObterTodos().FirstOrDefault(p => p.IdCliente == cliente.Id);
            if (result != null) cliente.ListaErros.Add("Existe(m) pedido(s) associados a este Cliente, exclusão não permtida!");
            return cliente;
        }



        #endregion remover clientes

        #region Consulta clientes
        public IEnumerable<Clientes> ObterTodos()
        {
            return repoclientes.ObterTodos();
        }

        public Clientes ObterPorId(int id)
        {
            return repoclientes.ObterPorId(id);
        }

        public Clientes ObterPorApelido(string apelido)
        {
            return repoclientes.ObterPorApelido(apelido);
        }

        public Clientes ObterPorCpfCnpj(string cpfcnpj)
        {
            return repoclientes.ObterPorCpfCnpj(cpfcnpj);
        }

        #endregion Consulta clientes

        public void Dispose()
        {
            repoclientes.Dispose();
            servicepedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
