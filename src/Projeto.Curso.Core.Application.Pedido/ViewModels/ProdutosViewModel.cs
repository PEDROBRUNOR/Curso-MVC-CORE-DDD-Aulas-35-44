using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Curso.Core.Application.Pedido.ViewModels
{
    public class ProdutosViewModel
    {
        public ProdutosViewModel()
        {
            ListaErros = new List<string>();
        }
        public List<string> ListaErros { get; set; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Apelido obrigatório!")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres!")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo 150 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Valor obrigatório!")]
        [Display(Name = "Valor do Produto")]
        public string Valor { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres!")]
        public string Unidade { get; set; }

        [Required(ErrorMessage = "Fornecedor obrigatório!")]
        [Display(Name = "Fornecedor")]
        public string IdFornecedor { get; set; }

        public string NomeFornecedor { get; set; }

        public byte[] Foto { get; set; }
    }
}
