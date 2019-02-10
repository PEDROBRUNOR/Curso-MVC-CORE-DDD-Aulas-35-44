using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Shared.Entidades;
using Projeto.Curso.Core.Infra.Data.Context;

namespace Projeto.Curso.Core.Infra.Data.Repository
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : EntidadeBase
    {
        protected ContextEFPedidos Db;
        protected DbSet<TEntidade> DbSet;

        public Repository(ContextEFPedidos context)
        {
            Db = context;
            DbSet = Db.Set<TEntidade>();
        }

        public virtual void Adicionar(TEntidade obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntidade obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remover(TEntidade obj)
        {
            DbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        protected string ObterStringConexao()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").
                Build();
            return config.GetConnectionString("DefaultConnection");
        }



        public void Dispose()
        {
            Db.Dispose();
        }

    }

}
