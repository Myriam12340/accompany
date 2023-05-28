using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class misson1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consultant = table.Column<int>(type: "int", nullable: false),
                    Manager = table.Column<int>(type: "int", nullable: false),
                    titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationClientRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationClientC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SatisficationRH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SatisficationC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteManager = table.Column<int>(type: "int", nullable: true),
                    FeedbackManager = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mission");
        }
    }
}
