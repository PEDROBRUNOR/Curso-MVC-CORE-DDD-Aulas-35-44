using Projeto.Curso.Core.Infra.Data.Context;
using Projeto.Curso.Core.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Curso.Core.Infra.Data.uOw
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextEFPedidos context;

        public UnitOfWork(ContextEFPedidos _context)
        {
            context = _context;
        }

        public void Commit(List<string> erros)
        {
            if (!erros.Any())
            {
                context.SaveChanges();
            }
        }
    }
}
