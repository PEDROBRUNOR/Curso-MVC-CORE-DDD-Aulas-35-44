using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit(List<string> erros);
    }
}
