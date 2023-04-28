using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tel1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Competance = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CvPdf = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entretien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Avis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidatId = table.Column<int>(type: "int", nullable: true),
                    RecruteurId = table.Column<int>(type: "int", nullable: true),
                    RecruteurSuivantId = table.Column<int>(type: "int", nullable: true),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionPoste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entretien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entretien_AspNetUsers_RecruteurId",
                        column: x => x.RecruteurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entretien_AspNetUsers_RecruteurSuivantId",
                        column: x => x.RecruteurSuivantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entretien_candidat_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "candidat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entretien_CandidatId",
                table: "entretien",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_entretien_RecruteurId",
                table: "entretien",
                column: "RecruteurId");

            migrationBuilder.CreateIndex(
                name: "IX_entretien_RecruteurSuivantId",
                table: "entretien",
                column: "RecruteurSuivantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entretien");

            migrationBuilder.DropTable(
                name: "candidat");
        }
    }
}
