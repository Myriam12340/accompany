using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class valideentretien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "valid",
                table: "entretien",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valid",
                table: "entretien");
        }
    }
}
