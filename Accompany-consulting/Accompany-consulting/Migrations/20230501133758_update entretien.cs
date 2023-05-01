using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class updateentretien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretien_AspNetUsers_RecruteurId",
                table: "entretien");

            migrationBuilder.DropForeignKey(
                name: "FK_entretien_AspNetUsers_RecruteurSuivantId",
                table: "entretien");

            migrationBuilder.DropForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien");

            migrationBuilder.DropIndex(
                name: "IX_entretien_RecruteurId",
                table: "entretien");

            migrationBuilder.DropIndex(
                name: "IX_entretien_RecruteurSuivantId",
                table: "entretien");

            migrationBuilder.DropColumn(
                name: "RecruteurId",
                table: "entretien");

            migrationBuilder.DropColumn(
                name: "RecruteurSuivantId",
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

            migrationBuilder.AddColumn<int>(
                name: "Recruteur",
                table: "entretien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecruteurSuivant",
                table: "entretien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien",
                column: "CandidatId",
                principalTable: "candidat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretien_candidat_CandidatId",
                table: "entretien");

            migrationBuilder.DropColumn(
                name: "Recruteur",
                table: "entretien");

            migrationBuilder.DropColumn(
                name: "RecruteurSuivant",
                table: "entretien");

            migrationBuilder.AlterColumn<int>(
                name: "CandidatId",
                table: "entretien",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RecruteurId",
                table: "entretien",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecruteurSuivantId",
                table: "entretien",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entretien_RecruteurId",
                table: "entretien",
                column: "RecruteurId");

            migrationBuilder.CreateIndex(
                name: "IX_entretien_RecruteurSuivantId",
                table: "entretien",
                column: "RecruteurSuivantId");

            migrationBuilder.AddForeignKey(
                name: "FK_entretien_AspNetUsers_RecruteurId",
                table: "entretien",
                column: "RecruteurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entretien_AspNetUsers_RecruteurSuivantId",
                table: "entretien",
                column: "RecruteurSuivantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
