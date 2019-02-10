using AutoMapper;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using Projeto.Curso.Core.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Services
{
    public class ApplicationProdutos : IApplicationProdutos
    {
        private readonly IServiceProdutos serviceProdutos;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationProdutos(IServiceProdutos _serviceProdutos,
                                   IMapper _mapper,
                                   IUnitOfWork _uow)
        {
            serviceProdutos = _serviceProdutos;
            mapper = _mapper;
            uow = _uow;
        }


        public ProdutosViewModel Adicionar(ProdutosViewModel produto)
        {
            var produtoresult = mapper.Map<ProdutosViewModel>(serviceProdutos.Adicionar(mapper.Map<Produtos>(produto)));
            uow.Commit(produtoresult.ListaErros);
            return mapper.Map<ProdutosViewModel>(produtoresult);
        }

        public ProdutosViewModel Atualizar(ProdutosViewModel produto)
        {
            var produtoresult = mapper.Map<ProdutosViewModel>(serviceProdutos.Atualizar(mapper.Map<Produtos>(produto)));
            uow.Commit(produtoresult.ListaErros);
            return mapper.Map<ProdutosViewModel>(produtoresult);
        }

        public ProdutosViewModel Remover(ProdutosViewModel produto)
        {
            var produtoresult = mapper.Map<ProdutosViewModel>(serviceProdutos.Remover(mapper.Map<Produtos>(produto)));
            uow.Commit(produtoresult.ListaErros);
            return mapper.Map<ProdutosViewModel>(produtoresult);
        }

        public IEnumerable<ProdutosViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<ProdutosViewModel>>(serviceProdutos.ObterTodos());
        }

        public ProdutosViewModel ObterPorId(int id)
        {
            return mapper.Map<ProdutosViewModel>(serviceProdutos.ObterPorId(id));
        }

        public ProdutosViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<ProdutosViewModel>(serviceProdutos.ObterPorApelido(apelido));
        }


        public ProdutosViewModel ObterPorNome(string nome)
        {
            return mapper.Map<ProdutosViewModel>(serviceProdutos.ObterPorNome(nome));
        }



        public void Dispose()
        {
            serviceProdutos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
