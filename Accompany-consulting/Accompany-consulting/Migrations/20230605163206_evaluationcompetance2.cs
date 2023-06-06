using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class evaluationcompetance2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eval_competance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hr = table.Column<int>(type: "int", nullable: false),
                    Date_evaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    notefinal = table.Column<int>(type: "int", nullable: false),
                    notemissions = table.Column<int>(type: "int", nullable: false),
                    decision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contrat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consultant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eval_competance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eval_competance");
        }
    }
}
