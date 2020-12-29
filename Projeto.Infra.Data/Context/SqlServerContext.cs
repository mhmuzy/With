using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Mappings;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Fornecimento>  Fornecimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Socio> Socios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new CompraMap());
            modelBuilder.ApplyConfiguration(new FornecimentoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new SocioMap());

            modelBuilder.Entity<Fornecedor>(entity =>
                {
                    entity.HasIndex(f => f.Nome).IsUnique();
                    entity.HasIndex(f => f.Cpf).IsUnique();
                    entity.HasIndex(f => f.Cnpj).IsUnique();
                    entity.HasIndex(f => f.Telefone).IsUnique();
                    entity.HasIndex(f => f.Celular).IsUnique();
                    entity.HasIndex(f => f.Email).IsUnique();
                });
            modelBuilder.Entity<Cliente>(entity => 
                {
                    entity.HasIndex(c => c.Nome).IsUnique();
                    entity.HasIndex(c => c.Telefone).IsUnique();
                    entity.HasIndex(c => c.Celular).IsUnique();
                    entity.HasIndex(c => c.Cpf).IsUnique();
                    entity.HasIndex(c => c.Email).IsUnique();
                });
            modelBuilder.Entity<Fornecedor>(entity =>
                {
                    entity.HasIndex(f => f.Nome).IsUnique();
                    entity.HasIndex(f => f.Telefone).IsUnique();
                    entity.HasIndex(f => f.Celular).IsUnique();
                    entity.HasIndex(f => f.Cnpj).IsUnique();
                    entity.HasIndex(f => f.Cpf).IsUnique();
                    entity.HasIndex(f => f.Email).IsUnique();
                });
            modelBuilder.Entity<Socio>(entity =>
                {
                    entity.HasIndex(s => s.Nome).IsUnique();
                    entity.HasIndex(s => s.Telefone).IsUnique();
                    entity.HasIndex(s => s.Celular).IsUnique();
                    entity.HasIndex(s => s.Cpf).IsUnique();
                    entity.HasIndex(s => s.Email).IsUnique();
                });
        }

        
    }
}
