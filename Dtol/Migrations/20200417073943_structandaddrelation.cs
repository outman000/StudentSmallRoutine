using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class structandaddrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Info_Station_Info_Station_Infoid",
                table: "Class_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Info_Station_Info_Station_InfoId",
                table: "Grade_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Health_Info_Student_Info_Student_InfoId",
                table: "Health_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Health_Info_facultystaff_Info_facultystaff_Infoid",
                table: "Health_Info");

            migrationBuilder.DropIndex(
                name: "IX_Grade_Info_Station_InfoId",
                table: "Grade_Info");

            migrationBuilder.DropIndex(
                name: "IX_Class_Info_Station_Infoid",
                table: "Class_Info");

            migrationBuilder.DropColumn(
                name: "Station_InfoId",
                table: "Grade_Info");

            migrationBuilder.DropColumn(
                name: "Station_Infoid",
                table: "Class_Info");

            migrationBuilder.RenameColumn(
                name: "facultystaff_Infoid",
                table: "Health_Info",
                newName: "facultystaff_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Health_Info_facultystaff_Infoid",
                table: "Health_Info",
                newName: "IX_Health_Info_facultystaff_InfoId");

            migrationBuilder.AlterColumn<int>(
                name: "Student_InfoId",
                table: "Health_Info",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Health_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffStation_Relate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Station_InfoId = table.Column<int>(nullable: true),
                    facultystaff_InfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffStation_Relate", x => x.id);
                    table.ForeignKey(
                        name: "FK_StaffStation_Relate_Station_Info_Station_InfoId",
                        column: x => x.Station_InfoId,
                        principalTable: "Station_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffStation_Relate_facultystaff_Info_facultystaff_InfoId",
                        column: x => x.facultystaff_InfoId,
                        principalTable: "facultystaff_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffStation_Relate_Station_InfoId",
                table: "StaffStation_Relate",
                column: "Station_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffStation_Relate_facultystaff_InfoId",
                table: "StaffStation_Relate",
                column: "facultystaff_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Health_Info_Student_Info_Student_InfoId",
                table: "Health_Info",
                column: "Student_InfoId",
                principalTable: "Student_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Health_Info_facultystaff_Info_facultystaff_InfoId",
                table: "Health_Info",
                column: "facultystaff_InfoId",
                principalTable: "facultystaff_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Health_Info_Student_Info_Student_InfoId",
                table: "Health_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Health_Info_facultystaff_Info_facultystaff_InfoId",
                table: "Health_Info");

            migrationBuilder.DropTable(
                name: "StaffStation_Relate");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Health_Info");

            migrationBuilder.RenameColumn(
                name: "facultystaff_InfoId",
                table: "Health_Info",
                newName: "facultystaff_Infoid");

            migrationBuilder.RenameIndex(
                name: "IX_Health_Info_facultystaff_InfoId",
                table: "Health_Info",
                newName: "IX_Health_Info_facultystaff_Infoid");

            migrationBuilder.AlterColumn<int>(
                name: "Student_InfoId",
                table: "Health_Info",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Station_InfoId",
                table: "Grade_Info",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Station_Infoid",
                table: "Class_Info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Info_Station_InfoId",
                table: "Grade_Info",
                column: "Station_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Info_Station_Infoid",
                table: "Class_Info",
                column: "Station_Infoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Info_Station_Info_Station_Infoid",
                table: "Class_Info",
                column: "Station_Infoid",
                principalTable: "Station_Info",
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
                name: "FK_Health_Info_Student_Info_Student_InfoId",
                table: "Health_Info",
                column: "Student_InfoId",
                principalTable: "Student_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Health_Info_facultystaff_Info_facultystaff_Infoid",
                table: "Health_Info",
                column: "facultystaff_Infoid",
                principalTable: "facultystaff_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
