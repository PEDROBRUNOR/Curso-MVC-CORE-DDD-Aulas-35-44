using AutoMapper;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using Projeto.Curso.Core.Application.Pedido.ViewModels.AgregracaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.DTO;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Infra.CrossCutting.Extensions;

namespace Projeto.Curso.Core.Application.Pedido.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Clientes, ClientesViewModel>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new ClientesViewModel
                     {
                         Id = src.Id,
                         ListaErros = src.ListaErros,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CpfCnpj = src.CPFCNPJ.Numero.FormatoCpfCnpj(),
                         Email = src.Email.Endereco,
                         Endereco = src.Endereco.Logradouro,
                         Bairro = src.Endereco.Bairro,
                         Cidade = src.Endereco.Cidade,
                         UF = src.Endereco.UF.UF,
                         CEP = src.Endereco.CEP.Codigo
                     };
                 });


            CreateMap<Fornecedores, FornecedoresViewModel>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new FornecedoresViewModel
                     {
                         Id = src.Id,
                         ListaErros = src.ListaErros,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CpfCnpj = src.CPFCNPJ.Numero.FormatoCpfCnpj(),
                         Email = src.Email.Endereco,
                         Endereco = src.Endereco.Logradouro,
                         Bairro = src.Endereco.Bairro,
                         Cidade = src.Endereco.Cidade,
                         UF = src.Endereco.UF.UF,
                         CEP = src.Endereco.CEP.Codigo
                     };
                 });

            CreateMap<Produtos, ProdutosViewModel>()
                   .ConvertUsing((src, dst) =>
                    {
                        return new ProdutosViewModel
                        {
                            ListaErros = src.ListaErros,
                            Id = src.Id,
                            Apelido = src.Apelido,
                            Nome = src.Nome,
                            Valor = src.Valor.Formatado("{0:#,###,##0.00}"),
                            Unidade = src.Unidade,
                            IdFornecedor = src.IdFornecedor.ToString(),
                            NomeFornecedor = src.Fornecedor != null ? src.Fornecedor.Nome : "",
                            Foto = src.Foto
                        };
                    });


            CreateMap<Pedidos, PedidosViewModel>()
                    .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => from.DataPedido.Formatado("{0:dd/MM/yyyy}")))
                    .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => from.DataEntrega.Formatado("{0:dd/MM/yyyy}")));

            CreateMap<PedidoDTO, PedidosViewModel>()
                   .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => from.DataPedido.Formatado("{0:dd/MM/yyyy}")))
                   .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => from.DataEntrega.Formatado("{0:dd/MM/yyyy}")))
                   .ForMember(to => to.ValorTotalProdutos, opt => opt.MapFrom(from => from.ValorTotalProdutos.Formatado("{0:#,###,##0.00}")));

            CreateMap<ItensPedidos, ItensPedidosViewModel>();

        }
    }
}
