using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropostaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class statusPropostaAjuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propostas_StatusProposta_StatusPropostaId",
                table: "Propostas");

            migrationBuilder.DropIndex(
                name: "IX_Propostas_StatusPropostaId",
                table: "Propostas");

            migrationBuilder.DropColumn(
                name: "StatusPropostaId",
                table: "Propostas");

            migrationBuilder.CreateIndex(
                name: "IX_Propostas_IdStatusProposta",
                table: "Propostas",
                column: "IdStatusProposta");

            migrationBuilder.AddForeignKey(
                name: "FK_Propostas_StatusProposta_IdStatusProposta",
                table: "Propostas",
                column: "IdStatusProposta",
                principalTable: "StatusProposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propostas_StatusProposta_IdStatusProposta",
                table: "Propostas");

            migrationBuilder.DropIndex(
                name: "IX_Propostas_IdStatusProposta",
                table: "Propostas");

            migrationBuilder.AddColumn<int>(
                name: "StatusPropostaId",
                table: "Propostas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
