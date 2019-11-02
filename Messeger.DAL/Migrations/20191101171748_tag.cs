using Microsoft.EntityFrameworkCore.Migrations;

namespace Messeger.DAL.Migrations
{
    public partial class tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "Members",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagName",
                table: "Members");
        }
    }
}
