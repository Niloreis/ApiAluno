using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMestre.Data.Entities
{
    public class Mestre
    {
        private Guid? _idMestre;
        private string? _nome;
        private string? _email;
        private string? _faixa;
        private string? _datadeNascimento; 
        private List<Alunos>? _alunos;


        public Guid? IdMestre { get => _idMestre; set => _idMestre = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Faixa { get => _faixa; set => _faixa = value; }
        public string? DatadeNascimento { get => _datadeNascimento; set => _datadeNascimento = value; }
        public List<Alunos>? Alunos { get => _alunos; set => _alunos = value; }
    }
}
