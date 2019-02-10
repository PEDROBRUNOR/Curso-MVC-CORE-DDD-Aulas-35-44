using System.Collections.Generic;

namespace Projeto.Curso.Core.Domain.Shared.Entidades
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            ListaErros = new List<string>();
        }
        public int Id { get; set; }
        public List<string> ListaErros { get; set; }
        public abstract bool EstaConsistente();
    }
}
