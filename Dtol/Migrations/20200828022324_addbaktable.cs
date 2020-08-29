using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class addbaktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Student_Info_Deleteid",
                table: "Health_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Student_Info_Delete",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Student_id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    SchoolCode = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true),
                    GradeCode = table.Column<string>(nullable: true),
                    GradeName = table.Column<string>(nullable: true),
                    ClassCode = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    class_InfoId = table.Column<int>(nullable: true),
                    StudentRegisterHeath_InfoId = table.Column<int>(nullable: true),
                    tag = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Info_Delete", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_Info_Delete_StudentRegisterHeath_Info_StudentRegisterHeath_InfoId",
                        column: x => x.StudentRegisterHeath_InfoId,
                        principalTable: "StudentRegisterHeath_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Info_Delete_Class_Info_class_InfoId",
                        column: x => x.class_InfoId,
                        principalTable: "Class_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Health_Info_Student_Info_Deleteid",
                table: "Health_Info",
                column: "Student_Info_Deleteid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_Delete_StudentRegisterHeath_InfoId",
                table: "Student_Info_Delete",
                column: "StudentRegisterHeath_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_Delete_class_InfoId",
                table: "Student_Info_Delete",
                column: "class_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Health_Info_Student_Info_Delete_Student_Info_Deleteid",
                table: "Health_Info",
                column: "Student_Info_Deleteid",
                principalTable: "Student_Info_Delete",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Health_Info_Student_Info_Delete_Student_Info_Deleteid",
                table: "Health_Info");

            migrationBuilder.DropTable(
                name: "Student_Info_Delete");

            migrationBuilder.DropIndex(
                name: "IX_Health_Info_Student_Info_Deleteid",
                table: "Health_Info");

            migrationBuilder.DropColumn(
                name: "Student_Info_Deleteid",
                table: "Health_Info");
        }
    }
}
