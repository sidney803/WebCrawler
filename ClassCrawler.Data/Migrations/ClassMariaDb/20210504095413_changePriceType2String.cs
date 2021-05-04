using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassCrawler.Data.Migrations.ClassMariaDb
{
    public partial class changePriceType2String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClassPrice",
                table: "ClassInfo",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ClassPrice",
                table: "ClassInfo",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
