using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apidelibros.Migrations
{
    /// <inheritdoc />
    public partial class UnParDeCosas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "libros",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "libros",
                newName: "Autor");
        }
    }
}
