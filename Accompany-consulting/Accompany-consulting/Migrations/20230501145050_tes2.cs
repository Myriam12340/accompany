using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class tes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien");

            migrationBuilder.DropIndex(
                name: "IX_entretien_CandidatId",
                table: "entretien");

            migrationBuilder.DropColumn(
                name: "CandidatId",
                table: "entretien");

            migrationBuilder.AddColumn<int>(
                name: "Candidat",
                table: "entretien",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Candidat",
                table: "entretien");

            migrationBuilder.AddColumn<int>(
                name: "CandidatId",
                table: "entretien",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entretien_CandidatId",
                table: "entretien",
                column: "CandidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien",
                column: "CandidatId",
                principalTable: "candidat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
