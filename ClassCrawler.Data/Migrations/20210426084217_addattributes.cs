﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassCrawler.Data.Migrations
{
    public partial class addattributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassInfo",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(nullable: true),
                    ClassImg = table.Column<string>(nullable: true),
                    ClassStatus = table.Column<string>(nullable: true),
                    ClassDate = table.Column<string>(nullable: true),
                    ClassTime = table.Column<string>(nullable: true),
                    ClassPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInfo", x => x.ClassId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassInfo");
        }
    }
}
