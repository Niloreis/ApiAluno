namespace ApiAluno.Services.Models
{
    public class PresencaGetModel
    {
       
            public Guid IdPresenca { get; set; }

            public Guid IdAluno { get; set; }

            public string? Presencas { get; set; }

            public string? DatadeHj { get; set; }

            public AlunoGetModel? Aluno { get; set; }


    }
}
