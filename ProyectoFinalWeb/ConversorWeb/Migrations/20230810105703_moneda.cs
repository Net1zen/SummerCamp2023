using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorWeb.Migrations
{
    /// <inheritdoc />
    public partial class moneda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Simbolo",
                table: "Moneda",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Moneda",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Moneda",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Moneda",
                newName: "Simbolo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Moneda",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Moneda",
                newName: "Codigo");
        }
    }
}
