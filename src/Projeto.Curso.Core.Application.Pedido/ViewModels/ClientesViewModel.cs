using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Curso.Core.Application.Pedido.ViewModels
{
    public class ClientesViewModel
    {
        public ClientesViewModel()
        {
            ListaErros = new List<string>();
        }

        public int Id { get; set; }
        public List<string> ListaErros { get; set; }

        [Required(ErrorMessage = "Apelido obrigatório!")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres!")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "CPF ou CNPJ")]
        [Required(ErrorMessage = "CPF ou CNPJ obrigatório!")]
        [MaxLength(18, ErrorMessage = "Máximo 18 caracteres!")]
        [MinLength(11, ErrorMessage = "Mínimo 11 caracteres!")]
        public string CpfCnpj { get; set; }

        [Display(Name = "E-Mail")]
        // [EmailAddress(ErrorMessage = "Digite um E-Mail válido!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail não é válido!")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Endereco { get; set; }

        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade obrigatória!")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF obrigatória!")]
        public string UF { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP inválido!")]
        public string CEP { get; set; }

    }
}
