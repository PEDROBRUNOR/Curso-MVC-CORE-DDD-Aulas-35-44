using System;
using System.Globalization;
using System.Linq;

namespace Projeto.Curso.Core.Infra.CrossCutting.Extensions
{
    public static class StringExtensions
    {

        public static string SomenteNumeros(this string strIn)
        {
            if (strIn != null)
            {
                var somentenumeros = new String(strIn.Where(c => Char.IsDigit(c)).ToArray());
                return somentenumeros;
            }
            return "";
        }

        public static string SomenteLetras(this string strIn)
        {
            if (strIn != null)
            {
                var somenteletras = new String(strIn.Where(c => Char.IsLetter(c)).ToArray());
                return somenteletras;
            }
            return "";
        }

        public static decimal ConvertDecimal(this string strIn, string masc)
        {
            var retorno = decimal.Parse(string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn));
            return retorno;
        }



        public static string FormatoCpfCnpj(this string strIn)
        {
            if (strIn != null && strIn != "")
            {
                if (strIn.Length == 11)
                {
                    return strIn.Substring(0, 3) + "." + strIn.Substring(3, 3) + "." + strIn.Substring(6, 3) + "-" + strIn.Substring(9, 2);
                }
                if (strIn.Length == 14)
                {
                    return strIn.Substring(0, 2) + "." + strIn.Substring(2, 3) + "." + strIn.Substring(5, 3) + "/" + strIn.Substring(8, 4) + "-" + strIn.Substring(12, 2);
                }
            }
            return "";
        }

    }
}
