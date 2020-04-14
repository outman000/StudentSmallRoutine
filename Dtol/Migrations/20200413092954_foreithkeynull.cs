using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class foreithkeynull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Info_Grade_Info_Grade_InfoId",
                table: "Class_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_facultystaff_Info_Health_Info_Health_InfoId",
                table: "facultystaff_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Info_Station_Info_Station_InfoId",
                table: "Grade_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Station_Info_School_Info_School_InfoId",
                table: "Station_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Health_Info_Health_InfoId",
                table: "Student_Info");

            migrationBuilder.AlterColumn<int>(
                name: "Health_InfoId",
                table: "Student_Info",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "School_InfoId",
                table: "Station_Info",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Station_InfoId",
                table: "Grade_Info",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Health_InfoId",
                table: "facultystaff_Info",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Grade_InfoId",
                table: "Class_Info",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Info_Grade_Info_Grade_InfoId",
                table: "Class_Info",
                column: "Grade_InfoId",
                principalTable: "Grade_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_facultystaff_Info_Health_Info_Health_InfoId",
                table: "facultystaff_Info",
                column: "Health_InfoId",
                principalTable: "Health_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Info_Station_Info_Station_InfoId",
                table: "Grade_Info",
                column: "Station_InfoId",
                principalTable: "Station_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Info_School_Info_School_InfoId",
                table: "Station_Info",
                column: "School_InfoId",
                principalTable: "School_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Health_Info_Health_InfoId",
                table: "Student_Info",
                column: "Health_InfoId",
                principalTable: "Health_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Info_Grade_Info_Grade_InfoId",
                table: "Class_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_facultystaff_Info_Health_Info_Health_InfoId",
                table: "facultystaff_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Info_Station_Info_Station_InfoId",
                table: "Grade_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Station_Info_School_Info_School_InfoId",
                table: "Station_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Health_Info_Health_InfoId",
                table: "Student_Info");

            migrationBuilder.AlterColumn<int>(
                name: "Health_InfoId",
                table: "Student_Info",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "School_InfoId",
                table: "Station_Info",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Station_InfoId",
                table: "Grade_Info",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Health_InfoId",
                table: "facultystaff_Info",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Grade_InfoId",
                table: "Class_Info",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Info_Grade_Info_Grade_InfoId",
                table: "Class_Info",
                column: "Grade_InfoId",
                principalTable: "Grade_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_facultystaff_Info_Health_Info_Health_InfoId",
                table: "facultystaff_Info",
                column: "Health_InfoId",
                principalTable: "Health_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Info_Station_Info_Station_InfoId",
                table: "Grade_Info",
                column: "Station_InfoId",
                principalTable: "Station_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Info_School_Info_School_InfoId",
                table: "Station_Info",
                column: "School_InfoId",
                principalTable: "School_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Health_Info_Health_InfoId",
                table: "Student_Info",
                column: "Health_InfoId",
                principalTable: "Health_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
