using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class relate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Info_Role_User_System_User_SystemId",
                table: "User_Relate_Info_Role");

            migrationBuilder.AlterColumn<int>(
                name: "User_SystemId",
                table: "User_Relate_Info_Role",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "User_InfoId",
                table: "User_Relate_Info_Role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Info_Role_User_InfoId",
                table: "User_Relate_Info_Role",
                column: "User_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Info_Role_User_Info_User_InfoId",
                table: "User_Relate_Info_Role",
                column: "User_InfoId",
                principalTable: "User_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Info_Role_User_System_User_SystemId",
                table: "User_Relate_Info_Role",
                column: "User_SystemId",
                principalTable: "User_System",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Info_Role_User_Info_User_InfoId",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Info_Role_User_System_User_SystemId",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropIndex(
                name: "IX_User_Relate_Info_Role_User_InfoId",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropColumn(
                name: "User_InfoId",
                table: "User_Relate_Info_Role");

            migrationBuilder.AlterColumn<int>(
                name: "User_SystemId",
                table: "User_Relate_Info_Role",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Info_Role_User_System_User_SystemId",
                table: "User_Relate_Info_Role",
                column: "User_SystemId",
                principalTable: "User_System",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
