using AutoMapper;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using Projeto.Curso.Core.Application.Pedido.ViewModels.AgregracaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Shared.ValueObjects;
using Projeto.Curso.Core.Infra.CrossCutting.Extensions;
using System;

namespace Projeto.Curso.Core.Application.Pedido.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientesViewModel, Clientes>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new Clientes
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CPFCNPJ = new CpfCnpjVO
                         {
                             Numero = src.CpfCnpj.SomenteNumeros()
                         },
                         Email = new EmailVO
                         {
                             Endereco = src.Email
                         },
                         Endereco = new EnderecoVO
                         {
                             Logradouro = src.Endereco,
                             Bairro = src.Bairro,
                             Cidade = src.Cidade,
                             UF = new UfVO
                             {
                                 UF = src.UF
                             },
                             CEP = new CepVO
                             {
                                 Codigo = src.CEP
                             }
                         }

                     };
                 });

            CreateMap<FornecedoresViewModel, Fornecedores>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new Fornecedores
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CPFCNPJ = new CpfCnpjVO
                         {
                             Numero = src.CpfCnpj.SomenteNumeros()
                         },
                         Email = new EmailVO
                         {
                             Endereco = src.Email
                         },
                         Endereco = new EnderecoVO
                         {
                             Logradouro = src.Endereco,
                             Bairro = src.Bairro,
                             Cidade = src.Cidade,
                             UF = new UfVO
                             {
                                 UF = src.UF
                             },
                             CEP = new CepVO
                             {
                                 Codigo = src.CEP
                             }
                         }
                     };
                 });

            CreateMap<ProdutosViewModel, Produtos>()
                    .ForMember(to => to.Valor, opt => opt.MapFrom(from => from.Valor.ConvertDecimal("{0:#,###,##0.00}")));

            CreateMap<PedidosViewModel, Pedidos>()
                    .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataPedido)))
                    .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataEntrega)));

            CreateMap<ItensPedidosViewModel, ItensPedidos>();
        }

    }
}
