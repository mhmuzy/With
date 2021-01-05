using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.CodCliente);

            builder.Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();

            //builder.Property(c => c.Produto.CodProduto)
            //    .IsRequired();

            builder.Property(c => c.FormaPagamento)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(c => c.Celular)
                .HasMaxLength(17)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Endereco)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
