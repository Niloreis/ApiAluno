using System.ComponentModel.DataAnnotations;

namespace ApiAluno.Services.Models
{
    public class MestreGetModel
    {
        public Guid IdMestre { get; set; }
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Faixa { get; set; }

        public string? Datadenascimento { get; set; }
    }
}
