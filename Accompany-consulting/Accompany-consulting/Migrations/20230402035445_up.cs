using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statut_relationnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fonction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Société = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_integration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Cin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultant");
        }
    }
}
