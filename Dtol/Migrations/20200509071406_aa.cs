using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Info_Role_User_System_User_SystemId",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropIndex(
                name: "IX_User_Relate_Info_Role_User_SystemId",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropColumn(
                name: "User_SystemId",
                table: "User_Relate_Info_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_SystemId",
                table: "User_Relate_Info_Role",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Info_Role_User_SystemId",
                table: "User_Relate_Info_Role",
                column: "User_SystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Info_Role_User_System_User_SystemId",
                table: "User_Relate_Info_Role",
                column: "User_SystemId",
                principalTable: "User_System",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
