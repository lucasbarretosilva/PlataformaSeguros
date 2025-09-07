using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropostaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class statusProposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Propostas",
                newName: "StatusPropostaId");

            migrationBuilder.AddColumn<int>(
                name: "IdStatusProposta",
                table: "Propostas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusProposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusProposta", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propostas_StatusPropostaId",
                table: "Propostas",
                column: "StatusPropostaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Propostas_StatusProposta_StatusPropostaId",
                table: "Propostas",
                column: "StatusPropostaId",
                principalTable: "StatusProposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propostas_StatusProposta_StatusPropostaId",
                table: "Propostas");

            migrationBuilder.DropTable(
                name: "StatusProposta");

            migrationBuilder.DropIndex(
                name: "IX_Propostas_StatusPropostaId",
                table: "Propostas");

            migrationBuilder.DropColumn(
                name: "IdStatusProposta",
                table: "Propostas");

            migrationBuilder.RenameColumn(
                name: "StatusPropostaId",
                table: "Propostas",
                newName: "Status");
        }
    }
}
