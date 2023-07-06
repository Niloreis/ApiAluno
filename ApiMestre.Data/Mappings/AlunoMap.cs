using ApiMestre.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Categoria
    /// </summary>
    public class AlunoMap : IEntityTypeConfiguration<Alunos>
    {
        public void Configure(EntityTypeBuilder<Alunos> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("ALUNO");

            //definir a chave primária da tabela
            builder.HasKey(a => a.IdAluno);

            //mapeamento dos campos
            builder.Property(a => a.IdAluno)
                .HasColumnName("IDALUNO");

            builder.Property(a => a.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Faixa)
               .HasColumnName("FAIXA")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(a => a.DatadeNascimento)
              .HasColumnName("DATANASCIMENTO")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(m => m.IdMestre)
               .HasColumnName("IDMESTRE")
               .IsRequired();

            builder.Property(p => p.IdPresenca)
            .HasColumnName("IDPRESECA")
            .IsRequired();


            //mapeamento do relacionamento 1 para muitos
            //e da foreign key (chave estrangeira)
            builder.HasOne(m => m.Mestre) //Produto TEM 1 Categoria
                .WithMany(a => a.Alunos) //Categoria TEM MUITOS Produtos
                .HasForeignKey(m => m.IdMestre);//Chave estrangeira

            
        }
    }
}