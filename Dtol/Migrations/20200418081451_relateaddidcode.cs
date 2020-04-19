using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class relateaddidcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "StaffStation_Relate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffCode",
                table: "StaffStation_Relate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassCode",
                table: "ClassManager_Relate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "ClassManager_Relate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "StaffStation_Relate");

            migrationBuilder.DropColumn(
                name: "StaffCode",
                table: "StaffStation_Relate");

            migrationBuilder.DropColumn(
                name: "ClassCode",
                table: "ClassManager_Relate");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "ClassManager_Relate");
        }
    }
}
