using System.ComponentModel.DataAnnotations;

namespace ApiAluno.Services.Models
{
    public class MestrePostModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do mestre.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma faixa.")]
        public string? Faixa { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma data.")]
        public string? Datadenascimento { get; set; }

        


    }
}
