using AutoMapper;
using Projeto.Curso.Core.Application.Pedido.Interfaces.AgregracaoPedidos;
using Projeto.Curso.Core.Application.Pedido.ViewModels.AgregracaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Services.AgregacaoPedidos
{
    public class ApplicationItensPedidos : IApplicationItensPedidos
    {
        private readonly IServiceItensPedidos serviceitenspedidos;
        private readonly IMapper mapper;

        public ApplicationItensPedidos(IServiceItensPedidos _serviceitenspedidos,
                                       IMapper _mapper)
        {
            serviceitenspedidos = _serviceitenspedidos;
            mapper = _mapper;
        }

        public ItensPedidosViewModel AdicionarItensPedidos(ItensPedidosViewModel item)
        {
            return mapper.Map<ItensPedidosViewModel>(serviceitenspedidos.AdicionarItensPedidos(mapper.Map<ItensPedidos>(item)));
        }

        public ItensPedidosViewModel AtulizarItensPedidos(ItensPedidosViewModel item)
        {
            return mapper.Map<ItensPedidosViewModel>(serviceitenspedidos.AtulizarItensPedidos(mapper.Map<ItensPedidos>(item)));
        }

        public ItensPedidosViewModel RemoverItensPedidos(ItensPedidosViewModel item)
        {
            return mapper.Map<ItensPedidosViewModel>(serviceitenspedidos.RemoverItensPedidos(mapper.Map<ItensPedidos>(item)));
        }

        public IEnumerable<ItensPedidosViewModel> ObterItensPedido(int idpedido)
        {
            return mapper.Map<IEnumerable<ItensPedidosViewModel>>(serviceitenspedidos.ObterItensPedido(idpedido));
        }

        public ItensPedidosViewModel ObterItensPedidosPorId(int id)
        {
            return mapper.Map<ItensPedidosViewModel>(serviceitenspedidos.ObterItensPedidosPorId(id));
        }

        public IEnumerable<ItensPedidosViewModel> ObterItensPedidoProdutoEspecifico(int idproduto)
        {
            return mapper.Map<IEnumerable<ItensPedidosViewModel>>(serviceitenspedidos.ObterItensPedidoProdutoEspecifico(idproduto));
        }

        public void Dispose()
        {
            serviceitenspedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
