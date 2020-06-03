using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class AddTable0529001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Group",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    StationNames = table.Column<string>(maxLength: 500, nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    Creatdate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    Updatedate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    bak1 = table.Column<string>(maxLength: 1000, nullable: true),
                    bak2 = table.Column<string>(maxLength: 1000, nullable: true),
                    bak3 = table.Column<string>(maxLength: 1000, nullable: true),
                    bak4 = table.Column<string>(maxLength: 1000, nullable: true),
                    bak5 = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Group", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Group");
        }
    }
}
