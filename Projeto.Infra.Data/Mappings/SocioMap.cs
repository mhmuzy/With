using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class SocioMap : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            //builder.ToTable("");

            builder.HasKey(s => s.Matricula);

            builder.Property(s => s.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Telefone)
                .HasMaxLength(16);

            builder.Property(s => s.Celular)
                .HasMaxLength(17);

            builder.Property(s => s.Cpf)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Endereco)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
