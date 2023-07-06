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
    /// Classe de mapeamento para a entidade Produto
    /// </summary>
    public class MestreMap : IEntityTypeConfiguration<Mestre>
    {
        public void Configure(EntityTypeBuilder<Mestre> builder)
        {
            //nome da tabela
            builder.ToTable("METRE");

            //chave primária
            builder.HasKey(m => m.IdMestre);

            //mapeamento dos campos
            builder.Property(m => m.IdMestre)
                .HasColumnName("IDMESTRE");

            builder.Property(m => m.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.Email)
                .HasColumnName("EMIAL")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(m => m.Faixa)
                 .HasColumnName("FAIXA")
                 .HasMaxLength(50)
                 .IsRequired();

            builder.Property(m => m.DatadeNascimento)
             .HasColumnName("DATANASCIMENTO")
             .HasMaxLength(50)
             .IsRequired();

           
        }
    }
}
