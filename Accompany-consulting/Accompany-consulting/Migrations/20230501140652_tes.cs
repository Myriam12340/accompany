using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class tes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien");

            migrationBuilder.AlterColumn<int>(
                name: "CandidatId",
                table: "entretien",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien",
                column: "CandidatId",
                principalTable: "candidat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien");

            migrationBuilder.AlterColumn<int>(
                name: "CandidatId",
                table: "entretien",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien",
                column: "CandidatId",
                principalTable: "candidat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
