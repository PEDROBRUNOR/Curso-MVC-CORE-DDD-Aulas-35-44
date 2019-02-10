using AutoMapper;
using Projeto.Curso.Core.Application.Pedido.Interfaces.AgregracaoPedidos;
using Projeto.Curso.Core.Application.Pedido.ViewModels.AgregracaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedido.Services.AgregacaoPedidos
{
    public class ApplicationPedidos : IApplicationPedidos
    {
        private readonly IServicePedidos servicepedidos;
        private readonly IMapper mapper;

        public ApplicationPedidos(IServicePedidos _servicepedidos,
                                  IMapper _mapper)
        {
            servicepedidos = _servicepedidos;
            mapper = _mapper;
        }


        public PedidosViewModel Adicionar(PedidosViewModel pedido)
        {
            return mapper.Map<PedidosViewModel>(servicepedidos.Adicionar(mapper.Map<Pedidos>(pedido)));
        }

        public PedidosViewModel Atualizar(PedidosViewModel pedido)
        {
            return mapper.Map<PedidosViewModel>(servicepedidos.Atualizar(mapper.Map<Pedidos>(pedido)));
        }

        public PedidosViewModel Remover(PedidosViewModel pedido)
        {
            return mapper.Map<PedidosViewModel>(servicepedidos.Remover(mapper.Map<Pedidos>(pedido)));
        }


        public IEnumerable<PedidosViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<PedidosViewModel>>(servicepedidos.ObterTodos());
        }

        public PedidosViewModel ObterPorId(int id)
        {
            return mapper.Map<PedidosViewModel>(servicepedidos.ObterPorId(id));
        }

        public PedidosViewModel ObterPedidoCompleto(int id)
        {
            return mapper.Map<PedidosViewModel>(servicepedidos.ObterPedidoCompleto(id));
        }

        public IEnumerable<PedidosViewModel> ObterListagemPedidos()
        {
            return mapper.Map<IEnumerable<PedidosViewModel>>(servicepedidos.ObterListagemPedidos());
        }

        public void Dispose()
        {
            servicepedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
