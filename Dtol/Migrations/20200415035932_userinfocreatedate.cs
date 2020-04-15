using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class userinfocreatedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "openid",
                table: "User_Info");

            migrationBuilder.DropColumn(
                name: "username",
                table: "User_Info");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "User_Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "User_Info");

            migrationBuilder.AddColumn<string>(
                name: "openid",
                table: "User_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "User_Info",
                nullable: true);
        }
    }
}
