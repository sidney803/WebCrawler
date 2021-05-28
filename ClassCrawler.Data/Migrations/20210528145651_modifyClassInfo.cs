using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassCrawler.Data.Migrations
{
    public partial class modifyClassInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               
               name: "ClassId",
               table: "ClassInfo",
               type: "varchar",
               nullable: false,
               //collation: "utf8mb4",
               oldClrType: typeof(string),
               oldType: "longtext",
               oldMaxLength: 100,
               oldNullable: true)
               .Annotation("MySql:CharSet", "utf8mb4")
               .OldAnnotation("MySql:CharSet", "latin1")
               .OldAnnotation("Relational:Collation", "latin1_swedish_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(

              name: "ClassId",
              table: "ClassInfo",
              type: "varchar",
              nullable: false,
              //collation: "utf8mb4",
              oldClrType: typeof(string),
              oldType: "longtext",
              oldMaxLength: 100,
              oldNullable: true)
              .Annotation("MySql:CharSet", "utf8mb4")
              .OldAnnotation("MySql:CharSet", "latin1")
              .OldAnnotation("Relational:Collation", "latin1_swedish_ci");
        }
    }
}
