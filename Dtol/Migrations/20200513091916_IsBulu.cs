using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class IsBulu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsBulu",
                table: "Health_Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBulu",
                table: "Health_Info");
        }
    }
}
