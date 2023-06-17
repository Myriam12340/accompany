using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class Budge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Budge",
                table: "eval__mensuel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budge",
                table: "eval__mensuel");
        }
    }
}
