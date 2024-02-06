using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEmpresas.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    IDEMPRESA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEFANTASIA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RAZAOSOCIAL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.IDEMPRESA);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    IDFUNCIONARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MATRICULA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DATAADMISSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDEMPRESA = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.IDFUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_EMPRESA_IDEMPRESA",
                        column: x => x.IDEMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "IDEMPRESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_IDEMPRESA",
                table: "FUNCIONARIO",
                column: "IDEMPRESA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "EMPRESA");
        }
    }
}
