using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEmpresas.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Neo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "EMPRESA",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_CPF",
                table: "FUNCIONARIO",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_MATRICULA",
                table: "FUNCIONARIO",
                column: "MATRICULA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_CNPJ",
                table: "EMPRESA",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_RAZAOSOCIAL",
                table: "EMPRESA",
                column: "RAZAOSOCIAL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIO_CPF",
                table: "FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIO_MATRICULA",
                table: "FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_EMPRESA_CNPJ",
                table: "EMPRESA");

            migrationBuilder.DropIndex(
                name: "IX_EMPRESA_RAZAOSOCIAL",
                table: "EMPRESA");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "EMPRESA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
