using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class StudentRegisterHeath_Info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_Health_Info_Health_InfoId",
                table: "Student_Info");

            migrationBuilder.RenameColumn(
                name: "Health_InfoId",
                table: "Student_Info",
                newName: "StudentRegisterHeath_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Info_Health_InfoId",
                table: "Student_Info",
                newName: "IX_Student_Info_StudentRegisterHeath_InfoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Createdate",
                table: "Health_Info",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Student_InfoId",
                table: "Health_Info",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "facultystaff_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentRegisterHeath_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Idnumber = table.Column<string>(nullable: true),
                    Residencetemporary = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Guardian = table.Column<string>(nullable: true),
                    IsleaveJin = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    BackJinDate = table.Column<DateTime>(nullable: true),
                    IsPassHubei = table.Column<string>(nullable: true),
                    PassHubeiDetail = table.Column<string>(nullable: true),
                    Traffic = table.Column<string>(nullable: true),
                    Peers = table.Column<string>(nullable: true),
                    PeersTelephone = table.Column<string>(nullable: true),
                    ForteenDaysExcepting = table.Column<string>(nullable: true),
                    BeforeTianjin = table.Column<string>(nullable: true),
                    Temperature = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegisterHeath_Info", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Health_Info_Student_InfoId",
                table: "Health_Info",
                column: "Student_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Health_Info_Student_Info_Student_InfoId",
                table: "Health_Info",
                column: "Student_InfoId",
                principalTable: "Student_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_StudentRegisterHeath_Info_StudentRegisterHeath_InfoId",
                table: "Student_Info",
                column: "StudentRegisterHeath_InfoId",
                principalTable: "StudentRegisterHeath_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Health_Info_Student_Info_Student_InfoId",
                table: "Health_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Info_StudentRegisterHeath_Info_StudentRegisterHeath_InfoId",
                table: "Student_Info");

            migrationBuilder.DropTable(
                name: "StudentRegisterHeath_Info");

            migrationBuilder.DropIndex(
                name: "IX_Health_Info_Student_InfoId",
                table: "Health_Info");

            migrationBuilder.DropColumn(
                name: "Createdate",
                table: "Health_Info");

            migrationBuilder.DropColumn(
                name: "Student_InfoId",
                table: "Health_Info");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "facultystaff_Info");

            migrationBuilder.RenameColumn(
                name: "StudentRegisterHeath_InfoId",
                table: "Student_Info",
                newName: "Health_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Info_StudentRegisterHeath_InfoId",
                table: "Student_Info",
                newName: "IX_Student_Info_Health_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Info_Health_Info_Health_InfoId",
                table: "Student_Info",
                column: "Health_InfoId",
                principalTable: "Health_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
