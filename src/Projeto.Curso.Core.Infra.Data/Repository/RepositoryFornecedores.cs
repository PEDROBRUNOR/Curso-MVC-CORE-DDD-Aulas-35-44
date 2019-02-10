using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repository
{
    public class RepositoryFornecedores : Repository<Fornecedores>, IRepositoryFornecedores
    {
        public RepositoryFornecedores(ContextEFPedidos context)
            : base(context)
        {

        }
        public override IEnumerable<Fornecedores> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores ORDER BY id DESC");
            return ExecutarDataReader(null, query.ToString());
        }

        public override Fornecedores ObterPorId(int id)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uID", id )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores WHERE id=@uID");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        public Fornecedores ObterPorApelido(string apelido)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uApelido", apelido )
                                   };
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores WHERE apelido=@uAPELIDO");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        public Fornecedores ObterPorCpfCnpj(string cpfcnpj)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uCPFCNPJ", cpfcnpj )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores WHERE CpfCnpj=@uCPFCNPJ");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }


        private Fornecedores AtribuirFornecedor(Fornecedores fornecedor, SqlDataReader reader)
        {
            fornecedor.Id = reader.GetInt32(0);
            fornecedor.Apelido = reader.SafeGetString(1);
            fornecedor.Nome = reader.SafeGetString(2);
            fornecedor.CPFCNPJ.Numero = reader.SafeGetString(3);
            fornecedor.Email.Endereco = reader.SafeGetString(4);
            fornecedor.Endereco.Logradouro = reader.SafeGetString(5);
            fornecedor.Endereco.Bairro = reader.SafeGetString(6);
            fornecedor.Endereco.Cidade = reader.SafeGetString(7);
            fornecedor.Endereco.UF.UF = reader.SafeGetString(8);
            fornecedor.Endereco.CEP.Codigo = reader.SafeGetString(9);
            return fornecedor;
        }

        private IEnumerable<Fornecedores> ExecutarDataReader(SqlParameter[] param, string sql)
        {
            string cn = ObterStringConexao();
            List<Fornecedores> fornecedores = new List<Fornecedores>();
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Fornecedores fornecedor = new Fornecedores();
                        fornecedor = AtribuirFornecedor(fornecedor, reader);
                        fornecedores.Add(fornecedor);
                    }
                }
                return fornecedores;
            }
        }
    }

}
