using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class User_System : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_System",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    UserPwd = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_System", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Relate_Info_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_SystemId = table.Column<int>(nullable: false),
                    Station_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Relate_Info_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Relate_Info_Role_Station_Info_Station_InfoId",
                        column: x => x.Station_InfoId,
                        principalTable: "Station_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Relate_Info_Role_User_System_User_SystemId",
                        column: x => x.User_SystemId,
                        principalTable: "User_System",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Info_Role_Station_InfoId",
                table: "User_Relate_Info_Role",
                column: "Station_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Info_Role_User_SystemId",
                table: "User_Relate_Info_Role",
                column: "User_SystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Relate_Info_Role");

            migrationBuilder.DropTable(
                name: "User_System");
        }
    }
}
