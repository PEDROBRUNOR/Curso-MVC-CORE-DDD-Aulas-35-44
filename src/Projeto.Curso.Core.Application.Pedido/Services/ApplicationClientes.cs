using AutoMapper;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using Projeto.Curso.Core.Infra.CrossCutting.Extensions;
using Projeto.Curso.Core.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Services
{
    public class ApplicationClientes : IApplicationClientes
    {
        private readonly IServiceClientes serviceclientes;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationClientes(IServiceClientes _serviceclientes,
                                   IMapper _mapper,
                                   IUnitOfWork _uow)
        {
            serviceclientes = _serviceclientes;
            mapper = _mapper;
            uow = _uow;
        }

        public ClientesViewModel Adicionar(ClientesViewModel cliente)
        {
            var clienteresult = mapper.Map<ClientesViewModel>(serviceclientes.Adicionar(mapper.Map<Clientes>(cliente)));
            uow.Commit(clienteresult.ListaErros);
            return mapper.Map<ClientesViewModel>(clienteresult);
        }

        public ClientesViewModel Atualizar(ClientesViewModel cliente)
        {
            var clienteresult = mapper.Map<ClientesViewModel>(serviceclientes.Atualizar(mapper.Map<Clientes>(cliente)));
            uow.Commit(clienteresult.ListaErros);
            return mapper.Map<ClientesViewModel>(clienteresult);
        }

        public ClientesViewModel Remover(ClientesViewModel cliente)
        {
            var clienteresult = mapper.Map<ClientesViewModel>(serviceclientes.Remover(mapper.Map<Clientes>(cliente)));
            uow.Commit(clienteresult.ListaErros);
            return mapper.Map<ClientesViewModel>(clienteresult);
        }
        public IEnumerable<ClientesViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<ClientesViewModel>>(serviceclientes.ObterTodos());
        }

        public ClientesViewModel ObterPorId(int id)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.ObterPorId(id));
        }

        public ClientesViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.ObterPorApelido(apelido));
        }

        public ClientesViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
        }

        public void Dispose()
        {
            serviceclientes.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
