using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class updateeval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Communication_interne_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Formation_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Outils_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessRH_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessusR_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pt24_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rapport_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Relation_com",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "suggestion",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Communication_interne_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "Formation_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "Outils_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "ProcessRH_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "ProcessusR_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "Pt24_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "Rapport_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "Relation_com",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "suggestion",
                table: "Evaluation");
        }
    }
}
