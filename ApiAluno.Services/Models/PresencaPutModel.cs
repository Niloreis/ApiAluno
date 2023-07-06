using System.ComponentModel.DataAnnotations;

namespace ApiAluno.Services.Models
{
    public class PresencaPutModel
    {
        [Required(ErrorMessage = "Por favor, coloque o id da presenca.")]
        public Guid IdPresenca { get; set; }

        [Required(ErrorMessage = "Por favor, coloque o id do aluno.")]
        public Guid IdAluno { get; set; }

        [Required(ErrorMessage = "Por favor, de a presença do aluno.")]
        public string? Presencas { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de hoje.")]
        public string? DatadeHj { get; set; }
    }
}
