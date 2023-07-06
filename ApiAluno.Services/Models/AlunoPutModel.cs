using System.ComponentModel.DataAnnotations;

namespace ApiAluno.Services.Models
{
    public class AlunoPutModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome da categoria.")]
        public string? Nome { get; set; }


        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma faixa.")]
        public string? Faixa { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma data.")]
        public string? DatadeNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do aluno.")]
        public Guid? IdAluno { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do mestre.")]
        public Guid? IdMestre { get; set; }
    }
}
