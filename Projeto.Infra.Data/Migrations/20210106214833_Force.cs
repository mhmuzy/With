using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class Force : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(maxLength: 16, nullable: false),
                    Celular = table.Column<string>(maxLength: 17, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodCliente);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    CodCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCompra = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CodCompra);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    CodFornecedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 17, nullable: true),
                    Telefone = table.Column<string>(maxLength: 16, nullable: true),
                    Celular = table.Column<string>(maxLength: 17, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.CodFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Fornecimento",
                columns: table => new
                {
                    CodFornecimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFornecimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecimento", x => x.CodFornecimento);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    CodProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.CodProduto);
                });

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Matricula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(maxLength: 16, nullable: true),
                    Celular = table.Column<string>(maxLength: 17, nullable: true),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.Matricula);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Celular",
                table: "Cliente",
                column: "Celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cpf",
                table: "Cliente",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "Cliente",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nome",
                table: "Cliente",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Telefone",
                table: "Cliente",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Celular",
                table: "Fornecedor",
                column: "Celular",
                unique: true,
                filter: "[Celular] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Cnpj",
                table: "Fornecedor",
                column: "Cnpj",
                unique: true,
                filter: "[Cnpj] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Cpf",
                table: "Fornecedor",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Email",
                table: "Fornecedor",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Nome",
                table: "Fornecedor",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Telefone",
                table: "Fornecedor",
                column: "Telefone",
                unique: true,
                filter: "[Telefone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_Celular",
                table: "Socio",
                column: "Celular",
                unique: true,
                filter: "[Celular] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_Cpf",
                table: "Socio",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socio_Email",
                table: "Socio",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socio_Nome",
                table: "Socio",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socio_Telefone",
                table: "Socio",
                column: "Telefone",
                unique: true,
                filter: "[Telefone] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Fornecimento");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Socio");
        }
    }
}
