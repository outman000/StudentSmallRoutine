using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class employkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facultystaff_Info_Health_Info_Health_InfoId",
                table: "facultystaff_Info");

            migrationBuilder.RenameColumn(
                name: "Health_InfoId",
                table: "facultystaff_Info",
                newName: "StudentRegisterHeath_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_facultystaff_Info_Health_InfoId",
                table: "facultystaff_Info",
                newName: "IX_facultystaff_Info_StudentRegisterHeath_InfoId");

            migrationBuilder.AddColumn<int>(
                name: "facultystaff_Infoid",
                table: "Health_Info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Health_Info_facultystaff_Infoid",
                table: "Health_Info",
                column: "facultystaff_Infoid");

            migrationBuilder.AddForeignKey(
                name: "FK_facultystaff_Info_StudentRegisterHeath_Info_StudentRegisterHeath_InfoId",
                table: "facultystaff_Info",
                column: "StudentRegisterHeath_InfoId",
                principalTable: "StudentRegisterHeath_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Health_Info_facultystaff_Info_facultystaff_Infoid",
                table: "Health_Info",
                column: "facultystaff_Infoid",
                principalTable: "facultystaff_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facultystaff_Info_StudentRegisterHeath_Info_StudentRegisterHeath_InfoId",
                table: "facultystaff_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Health_Info_facultystaff_Info_facultystaff_Infoid",
                table: "Health_Info");

            migrationBuilder.DropIndex(
                name: "IX_Health_Info_facultystaff_Infoid",
                table: "Health_Info");

            migrationBuilder.DropColumn(
                name: "facultystaff_Infoid",
                table: "Health_Info");

            migrationBuilder.RenameColumn(
                name: "StudentRegisterHeath_InfoId",
                table: "facultystaff_Info",
                newName: "Health_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_facultystaff_Info_StudentRegisterHeath_InfoId",
                table: "facultystaff_Info",
                newName: "IX_facultystaff_Info_Health_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_facultystaff_Info_Health_Info_Health_InfoId",
                table: "facultystaff_Info",
                column: "Health_InfoId",
                principalTable: "Health_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
