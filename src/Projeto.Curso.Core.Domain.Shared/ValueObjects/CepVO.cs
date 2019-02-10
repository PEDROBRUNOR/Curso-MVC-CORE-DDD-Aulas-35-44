using Projeto.Curso.Core.Infra.CrossCutting.Extensions;

namespace Projeto.Curso.Core.Domain.Shared.ValueObjects
{
    public class CepVO
    {
        public string Codigo { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public bool Validar(string cep)
        {
            if (!string.IsNullOrEmpty(cep))
            {
                return ValidarCep(cep);
            }
            return true;
        }

        private bool ValidarCep(string cep)
        {
            if (cep.SomenteLetras().Length != 0) return false;
            if (cep.SomenteNumeros().Length != 8) return false;
            return true;
        }



    }
}
