using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class editnewtabless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Delete_StudentRegisterHeath_Info_StudentRegisterHeath_InfoId",
                table: "Student_Info_Delete");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Delete_Class_Info_class_InfoId",
                table: "Student_Info_Delete");

            migrationBuilder.DropIndex(
                name: "IX_Student_Info_Delete_StudentRegisterHeath_InfoId",
                table: "Student_Info_Delete");

            migrationBuilder.DropIndex(
                name: "IX_Student_Info_Delete_class_InfoId",
                table: "Student_Info_Delete");

            migrationBuilder.AlterColumn<int>(
                name: "class_InfoId",
                table: "Student_Info_Delete",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentRegisterHeath_InfoId",
                table: "Student_Info_Delete",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "class_InfoId",
                table: "Student_Info_Delete",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StudentRegisterHeath_InfoId",
                table: "Student_Info_Delete",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_Delete_StudentRegisterHeath_InfoId",
                table: "Student_Info_Delete",
                column: "StudentRegisterHeath_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_Delete_class_InfoId",
                table: "Student_Info_Delete",
                column: "class_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Delete_StudentRegisterHeath_Info_StudentRegisterHeath_InfoId",
                table: "Student_Info_Delete",
                column: "StudentRegisterHeath_InfoId",
                principalTable: "StudentRegisterHeath_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Delete_Class_Info_class_InfoId",
                table: "Student_Info_Delete",
                column: "class_InfoId",
                principalTable: "Class_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
