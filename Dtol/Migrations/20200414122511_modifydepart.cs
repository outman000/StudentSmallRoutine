using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class modifydepart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_Info_Depart_Info_Depart_Infoid",
                table: "Station_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Station_Info_School_Info_School_InfoId",
                table: "Station_Info");

            migrationBuilder.RenameColumn(
                name: "School_InfoId",
                table: "Station_Info",
                newName: "School_Infoid");

            migrationBuilder.RenameColumn(
                name: "Depart_Infoid",
                table: "Station_Info",
                newName: "Depart_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Station_Info_School_InfoId",
                table: "Station_Info",
                newName: "IX_Station_Info_School_Infoid");

            migrationBuilder.RenameIndex(
                name: "IX_Station_Info_Depart_Infoid",
                table: "Station_Info",
                newName: "IX_Station_Info_Depart_InfoId");

            migrationBuilder.AddColumn<int>(
                name: "Student_InfoId",
                table: "Depart_Info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Depart_Info_Student_InfoId",
                table: "Depart_Info",
                column: "Student_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depart_Info_Student_Info_Student_InfoId",
                table: "Depart_Info",
                column: "Student_InfoId",
                principalTable: "Student_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Info_Depart_Info_Depart_InfoId",
                table: "Station_Info",
                column: "Depart_InfoId",
                principalTable: "Depart_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Info_School_Info_School_Infoid",
                table: "Station_Info",
                column: "School_Infoid",
                principalTable: "School_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depart_Info_Student_Info_Student_InfoId",
                table: "Depart_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Station_Info_Depart_Info_Depart_InfoId",
                table: "Station_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Station_Info_School_Info_School_Infoid",
                table: "Station_Info");

            migrationBuilder.DropIndex(
                name: "IX_Depart_Info_Student_InfoId",
                table: "Depart_Info");

            migrationBuilder.DropColumn(
                name: "Student_InfoId",
                table: "Depart_Info");

            migrationBuilder.RenameColumn(
                name: "School_Infoid",
                table: "Station_Info",
                newName: "School_InfoId");

            migrationBuilder.RenameColumn(
                name: "Depart_InfoId",
                table: "Station_Info",
                newName: "Depart_Infoid");

            migrationBuilder.RenameIndex(
                name: "IX_Station_Info_School_Infoid",
                table: "Station_Info",
                newName: "IX_Station_Info_School_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Station_Info_Depart_InfoId",
                table: "Station_Info",
                newName: "IX_Station_Info_Depart_Infoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Info_Depart_Info_Depart_Infoid",
                table: "Station_Info",
                column: "Depart_Infoid",
                principalTable: "Depart_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Info_School_Info_School_InfoId",
                table: "Station_Info",
                column: "School_InfoId",
                principalTable: "School_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
