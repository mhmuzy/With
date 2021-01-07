using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class FornecimentoMap : IEntityTypeConfiguration<Fornecimento>
    {
        public void Configure(EntityTypeBuilder<Fornecimento> builder)
        {
            builder.ToTable("Fornecimento");

            builder.HasKey(f => f.CodFornecimento);

            //builder.Property(f => f.Fornecedor.CodFornecedor)
            //    .IsRequired();

            //builder.Property(f => f.Produto.CodProduto)
            //    .IsRequired();

            builder.Property(f => f.DataFornecimento)
                .HasColumnName("DataFornecimento");
        }
    }
}
