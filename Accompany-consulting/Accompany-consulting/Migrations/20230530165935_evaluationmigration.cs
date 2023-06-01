using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class evaluationmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hr = table.Column<int>(type: "int", nullable: false),
                    ProcessusR = table.Column<int>(type: "int", nullable: false),
                    CommunicationInterne = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<int>(type: "int", nullable: false),
                    Rapport = table.Column<int>(type: "int", nullable: false),
                    Outils = table.Column<int>(type: "int", nullable: false),
                    Pt24 = table.Column<int>(type: "int", nullable: false),
                    Formation = table.Column<int>(type: "int", nullable: false),
                    ProcessRH = table.Column<int>(type: "int", nullable: false),
                    AdmC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommunicationC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommunicationRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspritEquipeC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspritEquipeRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetInterneC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevCommercialC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VieCabinetC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetInterneRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevCommercialRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VieCabinetRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_evaluation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");
        }
    }
}
