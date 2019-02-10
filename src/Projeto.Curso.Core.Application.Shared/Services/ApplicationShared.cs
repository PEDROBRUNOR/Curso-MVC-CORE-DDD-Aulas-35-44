using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto.Curso.Core.Application.Shared.Intefaces;
using Projeto.Curso.Core.Domain.Shared.ValueObjects;
using System;

namespace Projeto.Curso.Core.Application.Shared.Services
{
    public class ApplicationShared : IApplicationShared
    {

        public SelectList ObterEstados()
        {
            UfVO uf = new UfVO();
            var estados = uf.ObterEstados();
            var ret = new SelectList(estados, "Codigo", "Codigo", "RJ");
            return ret;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
