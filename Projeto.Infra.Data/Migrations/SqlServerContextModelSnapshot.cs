// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.Infra.Data.Context;

namespace Projeto.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto.Infra.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("CodCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnName("Celular")
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnName("Endereco")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("Telefone")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("CodCliente");

                    b.HasIndex("Celular")
                        .IsUnique();

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("Telefone")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Projeto.Infra.Data.Entities.Compra", b =>
                {
                    b.Property<int>("CodCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCompra")
                        .HasColumnName("DataCompra")
                        .HasColumnType("datetime2");

                    b.HasKey("CodCompra");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Projeto.Infra.Data.Entities.Fornecedor", b =>
                {
                    b.Property<int>("CodFornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasColumnName("Celular")
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.Property<string>("Cnpj")
                        .HasColumnName("Cnpj")
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.Property<string>("Cpf")
                        .HasColumnName("Cpf")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnName("Endereco")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Telefone")
                        .HasColumnName("Telefone")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("CodFornecedor");

                    b.HasIndex("Celular")
                        .IsUnique()
                        .HasFilter("[Celular] IS NOT NULL");

                    b.HasIndex("Cnpj")
                        .IsUnique()
                        .HasFilter("[Cnpj] IS NOT NULL");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("[Cpf] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("Telefone")
                        .IsUnique()
                        .HasFilter("[Telefone] IS NOT NULL");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("Projeto.Infra.Data.Entities.Fornecimento", b =>
                {
                    b.Property<int>("CodFornecimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFornecimento")
                        .HasColumnName("DataFornecimento")
                        .HasColumnType("datetime2");

                    b.HasKey("CodFornecimento");

                    b.ToTable("Fornecimento");
                });

            modelBuilder.Entity("Projeto.Infra.Data.Entities.Produto", b =>
                {
                    b.Property<int>("CodProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<double>("Preco")
                        .HasColumnName("Preco")
                        .HasColumnType("float");

                    b.HasKey("CodProduto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Projeto.Infra.Data.Entities.Socio", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasColumnName("Celular")
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnName("Endereco")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Telefone")
                        .HasColumnName("Telefone")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("Matricula");

                    b.HasIndex("Celular")
                        .IsUnique()
                        .HasFilter("[Celular] IS NOT NULL");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("Telefone")
                        .IsUnique()
                        .HasFilter("[Telefone] IS NOT NULL");

                    b.ToTable("Socio");
                });
#pragma warning restore 612, 618
        }
    }
}
