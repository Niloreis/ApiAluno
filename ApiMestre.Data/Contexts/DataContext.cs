using ApiMestre.Data.Entities;
using ApiPresenca.Data.Mappings;
using ApiProdutos.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMestre.Data.Contexts
{
    /// <summary>
    /// Classe para conexão com o banco de dados através do EF
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para mapear a string de conexão do banco de dados no EF
        /// </summary>
        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)        
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Mestre;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        /// <summary>
        /// Método para adicionarmos as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new MestreMap ());
            modelBuilder.ApplyConfiguration(new PresencaMap());
        }
        /// <summary>
        /// Propriedade para fornecer os métodos de CRUD para Categoria
        /////// </summary>
        public DbSet<Alunos> Alunos { get; set; }

        /// <summary>
        /// Propriedade para fornecer os métodos de CRUD para Produto
        /// </summary>
        public DbSet<Mestre> Mestre { get; set; }

        /// <summary>
        /// Propriedade para fornecer os métodos de CRUD para Produto
        /// </summary>
        public DbSet<Presenca> Presenca { get; set; }
    }

}



