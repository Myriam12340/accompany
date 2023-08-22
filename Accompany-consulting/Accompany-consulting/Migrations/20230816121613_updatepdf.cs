using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accompany_consulting.Migrations
{
    public partial class updatepdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvPdf",
                table: "candidat");

            migrationBuilder.AddColumn<string>(
                name: "CvPdfUrl",
                table: "candidat",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvPdfUrl",
                table: "candidat");

            migrationBuilder.AddColumn<byte[]>(
                name: "CvPdf",
                table: "candidat",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
