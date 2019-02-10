using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Projeto.Curso.Core.Application.Shared.Intefaces
{
    public interface IApplicationShared : IDisposable
    {
        SelectList ObterEstados();
    }
}
