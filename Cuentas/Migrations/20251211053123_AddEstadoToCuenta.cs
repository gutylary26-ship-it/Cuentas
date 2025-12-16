using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuentas.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoToCuenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Cuenta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Cuenta");
        }
    }
}
