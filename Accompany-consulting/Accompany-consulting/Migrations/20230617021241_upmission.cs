using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class upmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargeC",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "ChargeRH",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "FeedbackManager",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "NoteManager",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "RelationClientC",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "RelationClientRH",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "RoleC",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "RoleRH",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "SatisficationC",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "SatisficationRH",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "evaluation",
                table: "Mission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChargeC",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargeRH",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedbackManager",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteManager",
                table: "Mission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelationClientC",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelationClientRH",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleC",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleRH",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SatisficationC",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SatisficationRH",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "evaluation",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
