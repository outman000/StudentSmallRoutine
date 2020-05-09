using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class datetimetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddTimeInterval",
                table: "Student_DayandNight_Info",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Except_Info_Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Except_Info_Employ",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Except_Info_Student");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Except_Info_Employ");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddTimeInterval",
                table: "Student_DayandNight_Info",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
