using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class class_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Class_Info_class_InfoIdid",
                table: "Student_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Class_Info_class_Infoid",
                table: "Student_Info");

            migrationBuilder.DropIndex(
                name: "IX_Student_Info_class_InfoIdid",
                table: "Student_Info");

            migrationBuilder.DropColumn(
                name: "class_InfoIdid",
                table: "Student_Info");

            migrationBuilder.RenameColumn(
                name: "class_Infoid",
                table: "Student_Info",
                newName: "class_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Info_class_Infoid",
                table: "Student_Info",
                newName: "IX_Student_Info_class_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Class_Info_class_InfoId",
                table: "Student_Info",
                column: "class_InfoId",
                principalTable: "Class_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Class_Info_class_InfoId",
                table: "Student_Info");

            migrationBuilder.RenameColumn(
                name: "class_InfoId",
                table: "Student_Info",
                newName: "class_Infoid");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Info_class_InfoId",
                table: "Student_Info",
                newName: "IX_Student_Info_class_Infoid");

            migrationBuilder.AddColumn<int>(
                name: "class_InfoIdid",
                table: "Student_Info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_class_InfoIdid",
                table: "Student_Info",
                column: "class_InfoIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Class_Info_class_InfoIdid",
                table: "Student_Info",
                column: "class_InfoIdid",
                principalTable: "Class_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Class_Info_class_Infoid",
                table: "Student_Info",
                column: "class_Infoid",
                principalTable: "Class_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
