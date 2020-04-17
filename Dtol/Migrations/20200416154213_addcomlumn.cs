using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addcomlumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsComeSchool",
                table: "Health_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsTouch",
                table: "Health_Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComeSchool",
                table: "Health_Info");

            migrationBuilder.DropColumn(
                name: "IsTouch",
                table: "Health_Info");
        }
    }
}
