using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repository
{
    public class RepositoryProdutos : Repository<Produtos>, IRepositoryProdutos
    {
        public RepositoryProdutos(ContextEFPedidos context)
            : base(context)
        {

        }

        public override IEnumerable<Produtos> ObterTodos()
        {
            var results = from p in Db.Produtos
                          join f in Db.Fornecedores on p.IdFornecedor equals f.Id
                          select new Produtos
                          {
                              Id = p.Id,
                              Apelido = p.Apelido,
                              Nome = p.Nome,
                              Valor = p.Valor,
                              Unidade = p.Unidade,
                              IdFornecedor = p.IdFornecedor,
                              Fornecedor = new Fornecedores
                              {
                                  Nome = f.Nome
                              }
                          };
            return results.ToList();
        }

        public override Produtos ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos WHERE id = @uID");
            var produtos = Db.Database.GetDbConnection().Query<Produtos>(query.ToString(), new { uID = id });
            return produtos.FirstOrDefault();
        }


        public Produtos ObterPorApelido(string apelido)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos WHERE apelido = @uAPELIDO
                          ");
            var produtos = Db.Database.GetDbConnection().Query<Produtos>(query.ToString(), new { uAPELIDO = apelido } );
            return produtos.FirstOrDefault();
        }

        public Produtos ObterPorNome(string nome)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos WHERE nome = @uNOME");
            var produtos = Db.Database.GetDbConnection().Query<Produtos>(query.ToString(), new { uNOME = nome });
            return produtos.FirstOrDefault();
        }

    }
}
