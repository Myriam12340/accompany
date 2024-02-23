using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class evalintegrationupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "commentaire_Aspects_RH",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "commentaire_travailler",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "commentaire_Aspects_RH",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "commentaire_travailler",
                table: "Evaluation");
        }
    }
}
