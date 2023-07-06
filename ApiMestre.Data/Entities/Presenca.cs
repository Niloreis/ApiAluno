using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMestre.Data.Entities
{
    public class Presenca
    {
        private Guid _idAluno;
        private Guid _idPresenca;
        private string? _presencas;
        private string? _datadehj;
        private Alunos? _alunos;
      //  private List<Alunos>? _aluno;

        public Guid IdPresenca { get => _idPresenca; set => _idPresenca = value; }
        public string? Presencas { get => _presencas; set => _presencas = value; }
        public string? Datadehj { get => _datadehj; set => _datadehj = value; }
        public Alunos? Alunos { get => _alunos; set => _alunos = value; }
        public Guid IdAluno { get => _idAluno; set => _idAluno = value; }
      //public List<Alunos>? Aluno { get => _aluno; set => _aluno = value; }
       
    }
}
