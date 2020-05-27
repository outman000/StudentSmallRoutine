using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class updatetablesnews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "User_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "openid",
                table: "User_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unionid",
                table: "User_Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "User_Info");

            migrationBuilder.DropColumn(
                name: "openid",
                table: "User_Info");

            migrationBuilder.DropColumn(
                name: "unionid",
                table: "User_Info");
        }
    }
}
