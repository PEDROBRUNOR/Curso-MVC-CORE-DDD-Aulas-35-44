using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.Interfaces.AgregracaoPedidos;
using Projeto.Curso.Core.Application.Pedido.Services;
using Projeto.Curso.Core.Application.Pedido.Services.AgregacaoPedidos;
using Projeto.Curso.Core.Application.Shared.Intefaces;
using Projeto.Curso.Core.Application.Shared.Services;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Services;
using Projeto.Curso.Core.Domain.Pedido.Services.AgregacaoPedidos;
using Projeto.Curso.Core.Infra.Data.Context;
using Projeto.Curso.Core.Infra.Data.Interfaces;
using Projeto.Curso.Core.Infra.Data.Repository;
using Projeto.Curso.Core.Infra.Data.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Infra.Data.uOw;

namespace Projeto.Curso.Core.Infra.CrossCutting.IoC
{
    public class NativeInjectorMapping
    {

        public static void RegisterServices(IServiceCollection service)
        {
            service.AddSingleton(Mapper.Configuration);
            service.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            service.AddScoped<IApplicationShared, ApplicationShared>();


            service.AddScoped<IApplicationClientes, ApplicationClientes>();
            service.AddScoped<IApplicationFornecedores, ApplicationFornecedores>();
            service.AddScoped<IApplicationProdutos, ApplicationProdutos>();
            service.AddScoped<IApplicationItensPedidos, ApplicationItensPedidos>();
            service.AddScoped<IApplicationPedidos, ApplicationPedidos>();

            service.AddScoped<IServiceClientes, ServiceClientes>();
            service.AddScoped<IServiceFornecedores, ServiceFornecedores>();
            service.AddScoped<IServiceProdutos, ServiceProdutos>();
            service.AddScoped<IServiceItensPedidos, ServiceItensPedidos>();
            service.AddScoped<IServicePedidos, ServicePedidos>();

            service.AddScoped<IRepositoryClientes, RepositoryClientes>();
            service.AddScoped<IRepositoryFornecedores, RepositoryFornecedores>();
            service.AddScoped<IRepositoryProdutos, RepositoryProdutos>();
            service.AddScoped<IRepositoryPedidos, RepositoryPedidos>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<ContextEFPedidos>();


        }

    }
}
