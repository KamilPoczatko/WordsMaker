using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordsMaker.Infrastructure.DAL.Migrations
{
    public partial class FirtMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictLangs",
                columns: table => new
                {
                    Lang = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictLangs", x => x.Lang);
                });

            migrationBuilder.CreateTable(
                name: "DictSufixes",
                columns: table => new
                {
                    SufixId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentLang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SufixType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictSufixes", x => x.SufixId);
                });

            migrationBuilder.CreateTable(
                name: "DictWords",
                columns: table => new
                {
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentLang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictWords", x => x.WordId);
                });

            migrationBuilder.CreateTable(
                name: "SufixToWord",
                columns: table => new
                {
                    SufixId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentLang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SufixToWord", x => new { x.WordId, x.SufixId });
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    CurrentWordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForeignWordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => new { x.CurrentWordId, x.ForeignWordId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictLangs");

            migrationBuilder.DropTable(
                name: "DictSufixes");

            migrationBuilder.DropTable(
                name: "DictWords");

            migrationBuilder.DropTable(
                name: "SufixToWord");

            migrationBuilder.DropTable(
                name: "Translations");
        }
    }
}
