using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class updateattribute3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Société",
                table: "Consultant");

            migrationBuilder.RenameColumn(
                name: "statut_relationnel",
                table: "Consultant",
                newName: "Societe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Societe",
                table: "Consultant",
                newName: "statut_relationnel");

            migrationBuilder.AddColumn<string>(
                name: "Société",
                table: "Consultant",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
