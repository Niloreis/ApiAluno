using ApiMestre.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPresenca.Data.Mappings
{
    public class PresencaMap : IEntityTypeConfiguration<Presenca>

    {
        public void Configure(EntityTypeBuilder<Presenca> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("PRESENCA");

            //definir a chave primária da tabela
            builder.HasKey(p => p.IdPresenca);

            builder.Property(p => p.IdPresenca)
            .HasColumnName("IDPRESNCA");

            //mapeamento dos campos
            builder.Property(p => p.Presencas)
                .HasColumnName("PRESENCAS");


            builder.Property(p => p.Datadehj)
                .HasColumnName("DATA_DE_HOJE")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.IdAluno)
                .HasColumnName("IDALUNO");


            //mapeamento do relacionamento 1 para muitos
            //e da foreign key (chave estrangeira)
            builder.HasOne(a => a.Alunos) //Produto TEM 1 Categoria
                .WithMany(p => p.Presenca) //Categoria TEM MUITOS Produtos
                .HasForeignKey(a  => a.IdAluno);//Chave estrangeira

        }
    }
}
