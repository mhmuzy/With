using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.CodProduto);

            builder.Property(p => p.Nome)
                .HasMaxLength(200)
                .IsRequired();

            //builder.Property(p => p.Fornecedor.CodFornecedor)
            //    .IsRequired();

            builder.Property(p => p.Preco)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(5000)
                .IsRequired();
        }
    }
}
