using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorWeb.Migrations
{
    /// <inheritdoc />
    public partial class addidmoneda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moneda",
                table: "Moneda");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Moneda",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moneda",
                table: "Moneda",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moneda",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Moneda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moneda",
                table: "Moneda",
                column: "Code");
        }
    }
}
