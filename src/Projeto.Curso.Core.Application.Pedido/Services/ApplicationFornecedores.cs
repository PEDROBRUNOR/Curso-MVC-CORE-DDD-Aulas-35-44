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
    public class ApplicationFornecedores : IApplicationFornecedores
    {

        private readonly IServiceFornecedores serviceFornecedores;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationFornecedores(IServiceFornecedores _serviceFornecedores,
                                       IMapper _mapper,
                                       IUnitOfWork _uow)
        {
            serviceFornecedores = _serviceFornecedores;
            mapper = _mapper;
            uow = _uow;
        }

        public FornecedoresViewModel Adicionar(FornecedoresViewModel fornecedor)
        {
            var fornecedorresult = mapper.Map<FornecedoresViewModel>(serviceFornecedores.Adicionar(mapper.Map<Fornecedores>(fornecedor)));
            uow.Commit(fornecedorresult.ListaErros);
            return mapper.Map<FornecedoresViewModel>(fornecedorresult);
        }

        public FornecedoresViewModel Atualizar(FornecedoresViewModel fornecedor)
        {
            var fornecedorresult = mapper.Map<FornecedoresViewModel>(serviceFornecedores.Atualizar(mapper.Map<Fornecedores>(fornecedor)));
            uow.Commit(fornecedorresult.ListaErros);
            return mapper.Map<FornecedoresViewModel>(fornecedorresult);
        }

        public FornecedoresViewModel Remover(FornecedoresViewModel fornecedor)
        {
            var fornecedorresult = mapper.Map<FornecedoresViewModel>(serviceFornecedores.Remover(mapper.Map<Fornecedores>(fornecedor)));
            uow.Commit(fornecedorresult.ListaErros);
            return mapper.Map<FornecedoresViewModel>(fornecedorresult);
        }

        public IEnumerable<FornecedoresViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<FornecedoresViewModel>>(serviceFornecedores.ObterTodos());
        }


        public FornecedoresViewModel ObterPorId(int id)
        {
            return mapper.Map<FornecedoresViewModel>(serviceFornecedores.ObterPorId(id));
        }

        public FornecedoresViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<FornecedoresViewModel>(serviceFornecedores.ObterPorApelido(apelido));
        }

        public FornecedoresViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<FornecedoresViewModel>(serviceFornecedores.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
        }

        public void Dispose()
        {
            serviceFornecedores.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
