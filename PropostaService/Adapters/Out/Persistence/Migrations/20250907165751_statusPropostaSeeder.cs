using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropostaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class statusPropostaSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StatusProposta",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Em análise" },
                    { 2, "Aprovada" },
                    { 3, "Rejeitada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusProposta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusProposta",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusProposta",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
