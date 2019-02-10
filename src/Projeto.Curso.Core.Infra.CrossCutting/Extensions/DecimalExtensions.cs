using System.Globalization;

namespace Projeto.Curso.Core.Infra.CrossCutting.Extensions
{
    public static class DecimalExtensions
    {
        public static string Formatado(this decimal strIn, string masc)
        {
            var retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn);
            return retorno;
        }
    }
}
