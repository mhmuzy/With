using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class CompraMap : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            //builder.ToTable("Compra");

            builder.HasKey(c => c.CodCompra);

            builder.Property(c => c.Cliente.CodCliente)
                .IsRequired();

            builder.Property(c => c.Produto.CodProduto)
                .IsRequired();

            builder.Property(c => c.DataCompra);
        }
    }
}
