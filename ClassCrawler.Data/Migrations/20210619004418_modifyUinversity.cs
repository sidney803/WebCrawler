using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassCrawler.Data.Migrations
{
    public partial class modifyUinversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RootUrl",
                table: "University",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RootUrl",
                table: "University");
        }
    }
}
