namespace ApiAluno.Services.Models
{
    public class AlunoGetModel
    {
        public Guid? IdAluno { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Faixa { get; set; }
        public string? DatadeNascimento { get; set;}
        public Guid? IdMestre { get; set; }


        public MestreGetModel? Mestre { get; set; }




    }
}
