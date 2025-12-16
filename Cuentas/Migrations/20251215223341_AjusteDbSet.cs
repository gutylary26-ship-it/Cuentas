using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuentas.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimiento",
                table: "Movimiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta");

            migrationBuilder.RenameTable(
                name: "Movimiento",
                newName: "Movimientos");

            migrationBuilder.RenameTable(
                name: "Cuenta",
                newName: "Cuentas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimientos",
                table: "Movimientos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimientos",
                table: "Movimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas");

            migrationBuilder.RenameTable(
                name: "Movimientos",
                newName: "Movimiento");

            migrationBuilder.RenameTable(
                name: "Cuentas",
                newName: "Cuenta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimiento",
                table: "Movimiento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta",
                column: "Id");
        }
    }
}
