using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMestre.Data.Entities
{
    public class Alunos
    {
        private Guid _idAluno;
        private string? _nome;
        private string? _email;
        private string? _faixa;
        private string? _dataNascimento;
        private Mestre? _mestre;
        private Guid _idMestre;
        private Guid _idPresenca;
        private List<Presenca>? _presenca;

        public Guid IdAluno { get => _idAluno; set => _idAluno = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Faixa { get => _faixa; set => _faixa = value; }
        public string? DatadeNascimento { get => _dataNascimento; set =>_dataNascimento = value; }
        public Mestre? Mestre { get => _mestre; set => _mestre = value; }
        public Guid IdMestre { get => _idMestre; set => _idMestre = value; }
        public Guid IdPresenca { get => _idPresenca; set => _idPresenca = value; }
        public List<Presenca>? Presenca { get => _presenca; set => _presenca = value; }
    }
}
