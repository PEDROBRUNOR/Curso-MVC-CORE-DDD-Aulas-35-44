using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repository
{
    public class RepositoryClientes : Repository<Clientes>, IRepositoryClientes
    {
        public RepositoryClientes(ContextEFPedidos context)
            : base(context)
        {

        }

        public override IEnumerable<Clientes> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes ORDER BY id DESC");
            return ExecutarDataReader(null, query.ToString());
        }

        public override Clientes ObterPorId(int id)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uID", id )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE id=@uID");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        public Clientes ObterPorApelido(string apelido)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uApelido", apelido )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE apelido=@uAPELIDO");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        public Clientes ObterPorCpfCnpj(string cpfcnpj)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uCPFCNPJ", cpfcnpj )
                                   };
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE CpfCnpj=@uCPFCNPJ");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        private Clientes AtribuirCliente(Clientes cliente, SqlDataReader reader)
        {
            cliente.Id = reader.GetInt32(0);
            cliente.Apelido = reader.SafeGetString(1);
            cliente.Nome = reader.SafeGetString(2);
            cliente.CPFCNPJ.Numero = reader.SafeGetString(3);
            cliente.Email.Endereco = reader.SafeGetString(4);
            cliente.Endereco.Logradouro = reader.SafeGetString(5);
            cliente.Endereco.Bairro = reader.SafeGetString(6);
            cliente.Endereco.Cidade = reader.SafeGetString(7);
            cliente.Endereco.UF.UF = reader.SafeGetString(8);
            cliente.Endereco.CEP.Codigo = reader.SafeGetString(9);
            return cliente;
        }

        private IEnumerable<Clientes> ExecutarDataReader(SqlParameter[] param, string sql)
        {
            string cn = ObterStringConexao();
            List<Clientes> clientes = new List<Clientes>();
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
                        Clientes cliente = new Clientes();
                        cliente = AtribuirCliente(cliente, reader);
                        clientes.Add(cliente);
                    }
                }
                return clientes;
            }
        }
    }
}
