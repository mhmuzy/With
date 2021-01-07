using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;


namespace Projeto.Infra.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(f => f.CodFornecedor);

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(14);

            builder.Property(f => f.Cnpj)
                .HasColumnName("Cnpj")
                .HasMaxLength(17);

            builder.Property(f => f.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(16);

            builder.Property(f => f.Celular)
                .HasColumnName("Celular")
                .HasMaxLength(17);

            builder.Property(f => f.Email)
                .HasColumnName("Email")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.Endereco)
                .HasColumnName("Endereco")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
