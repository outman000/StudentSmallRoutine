using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class modifydatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facultystaff_Info_Station_Info_station_InfoIdid",
                table: "facultystaff_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_facultystaff_Info_Station_Info_station_Infoid",
                table: "facultystaff_Info");

            migrationBuilder.DropIndex(
                name: "IX_facultystaff_Info_station_InfoIdid",
                table: "facultystaff_Info");

            migrationBuilder.DropColumn(
                name: "ClassCode",
                table: "facultystaff_Info");

            migrationBuilder.DropColumn(
                name: "station_InfoIdid",
                table: "facultystaff_Info");

            migrationBuilder.RenameColumn(
                name: "StationName",
                table: "Station_Info",
                newName: "StaffName");

            migrationBuilder.RenameColumn(
                name: "StationCode",
                table: "Station_Info",
                newName: "StaffCode");

            migrationBuilder.RenameColumn(
                name: "station_Infoid",
                table: "facultystaff_Info",
                newName: "station_InfoId");

            migrationBuilder.RenameColumn(
                name: "PermanentAddress",
                table: "facultystaff_Info",
                newName: "StaffName");

            migrationBuilder.RenameColumn(
                name: "GradeName",
                table: "facultystaff_Info",
                newName: "StaffCode");

            migrationBuilder.RenameColumn(
                name: "GradeCode",
                table: "facultystaff_Info",
                newName: "DepartName");

            migrationBuilder.RenameColumn(
                name: "ClassName",
                table: "facultystaff_Info",
                newName: "DepartCode");

            migrationBuilder.RenameIndex(
                name: "IX_facultystaff_Info_station_Infoid",
                table: "facultystaff_Info",
                newName: "IX_facultystaff_Info_station_InfoId");

            migrationBuilder.AddColumn<int>(
                name: "class_InfoIdid",
                table: "Student_Info",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "class_Infoid",
                table: "Student_Info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_class_InfoIdid",
                table: "Student_Info",
                column: "class_InfoIdid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_class_Infoid",
                table: "Student_Info",
                column: "class_Infoid");

            migrationBuilder.AddForeignKey(
                name: "FK_facultystaff_Info_Station_Info_station_InfoId",
                table: "facultystaff_Info",
                column: "station_InfoId",
                principalTable: "Station_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facultystaff_Info_Station_Info_station_InfoId",
                table: "facultystaff_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Class_Info_class_InfoIdid",
                table: "Student_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Class_Info_class_Infoid",
                table: "Student_Info");

            migrationBuilder.DropIndex(
                name: "IX_Student_Info_class_InfoIdid",
                table: "Student_Info");

            migrationBuilder.DropIndex(
                name: "IX_Student_Info_class_Infoid",
                table: "Student_Info");

            migrationBuilder.DropColumn(
                name: "class_InfoIdid",
                table: "Student_Info");

            migrationBuilder.DropColumn(
                name: "class_Infoid",
                table: "Student_Info");

            migrationBuilder.RenameColumn(
                name: "StaffName",
                table: "Station_Info",
                newName: "StationName");

            migrationBuilder.RenameColumn(
                name: "StaffCode",
                table: "Station_Info",
                newName: "StationCode");

            migrationBuilder.RenameColumn(
                name: "station_InfoId",
                table: "facultystaff_Info",
                newName: "station_Infoid");

            migrationBuilder.RenameColumn(
                name: "StaffName",
                table: "facultystaff_Info",
                newName: "PermanentAddress");

            migrationBuilder.RenameColumn(
                name: "StaffCode",
                table: "facultystaff_Info",
                newName: "GradeName");

            migrationBuilder.RenameColumn(
                name: "DepartName",
                table: "facultystaff_Info",
                newName: "GradeCode");

            migrationBuilder.RenameColumn(
                name: "DepartCode",
                table: "facultystaff_Info",
                newName: "ClassName");

            migrationBuilder.RenameIndex(
                name: "IX_facultystaff_Info_station_InfoId",
                table: "facultystaff_Info",
                newName: "IX_facultystaff_Info_station_Infoid");

            migrationBuilder.AddColumn<string>(
                name: "ClassCode",
                table: "facultystaff_Info",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "station_InfoIdid",
                table: "facultystaff_Info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_facultystaff_Info_station_InfoIdid",
                table: "facultystaff_Info",
                column: "station_InfoIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_facultystaff_Info_Station_Info_station_InfoIdid",
                table: "facultystaff_Info",
                column: "station_InfoIdid",
                principalTable: "Station_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_facultystaff_Info_Station_Info_station_Infoid",
                table: "facultystaff_Info",
                column: "station_Infoid",
                principalTable: "Station_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
