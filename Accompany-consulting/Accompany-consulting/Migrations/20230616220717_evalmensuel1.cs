using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class evalmensuel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eval__mensuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consultant = table.Column<int>(type: "int", nullable: false),
                    Manager = table.Column<int>(type: "int", nullable: false),
                    Mission = table.Column<int>(type: "int", nullable: false),
                    Qualité = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Délai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    périmètre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eval__mensuel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eval__mensuel");
        }
    }
}
