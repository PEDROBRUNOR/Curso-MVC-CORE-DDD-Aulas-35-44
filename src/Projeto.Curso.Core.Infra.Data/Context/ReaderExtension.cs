using System.Data.SqlClient;

namespace Projeto.Curso.Core.Infra.Data.Context
{
    public static class ReaderExtension
    {
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}
