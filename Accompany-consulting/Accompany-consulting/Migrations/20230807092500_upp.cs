using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class upp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "périmètre",
                table: "eval__mensuel",
                newName: "perimetre");

            migrationBuilder.RenameColumn(
                name: "Qualité",
                table: "eval__mensuel",
                newName: "Qualite");

            migrationBuilder.RenameColumn(
                name: "Délai",
                table: "eval__mensuel",
                newName: "Delai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "perimetre",
                table: "eval__mensuel",
                newName: "périmètre");

            migrationBuilder.RenameColumn(
                name: "Qualite",
                table: "eval__mensuel",
                newName: "Qualité");

            migrationBuilder.RenameColumn(
                name: "Delai",
                table: "eval__mensuel",
                newName: "Délai");
        }
    }
}
