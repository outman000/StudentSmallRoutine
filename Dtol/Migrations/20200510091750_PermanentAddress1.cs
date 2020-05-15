using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class PermanentAddress1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "StudentRegisterHeath_Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "StudentRegisterHeath_Info");
        }
    }
}
