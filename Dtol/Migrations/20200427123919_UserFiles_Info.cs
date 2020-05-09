using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class UserFiles_Info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserFiles_InfoId",
                table: "Except_Info_Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserFiles_InfoId",
                table: "Except_Info_Employ",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserFiles_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Idnumber = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    InternalName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    pathMobile = table.Column<string>(nullable: true),
                    path_server = table.Column<string>(nullable: true),
                    upload_percent = table.Column<string>(nullable: true),
                    ImgIndex = table.Column<int>(nullable: false),
                    Length = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles_Info", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Except_Info_Student_UserFiles_InfoId",
                table: "Except_Info_Student",
                column: "UserFiles_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Except_Info_Employ_UserFiles_InfoId",
                table: "Except_Info_Employ",
                column: "UserFiles_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Except_Info_Employ_facultystaff_InfoId",
                table: "Except_Info_Employ",
                column: "facultystaff_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Except_Info_Employ_UserFiles_Info_UserFiles_InfoId",
                table: "Except_Info_Employ",
                column: "UserFiles_InfoId",
                principalTable: "UserFiles_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Except_Info_Employ_facultystaff_Info_facultystaff_InfoId",
                table: "Except_Info_Employ",
                column: "facultystaff_InfoId",
                principalTable: "facultystaff_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Except_Info_Student_UserFiles_Info_UserFiles_InfoId",
                table: "Except_Info_Student",
                column: "UserFiles_InfoId",
                principalTable: "UserFiles_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Except_Info_Employ_UserFiles_Info_UserFiles_InfoId",
                table: "Except_Info_Employ");

            migrationBuilder.DropForeignKey(
                name: "FK_Except_Info_Employ_facultystaff_Info_facultystaff_InfoId",
                table: "Except_Info_Employ");

            migrationBuilder.DropForeignKey(
                name: "FK_Except_Info_Student_UserFiles_Info_UserFiles_InfoId",
                table: "Except_Info_Student");

            migrationBuilder.DropTable(
                name: "UserFiles_Info");

            migrationBuilder.DropIndex(
                name: "IX_Except_Info_Student_UserFiles_InfoId",
                table: "Except_Info_Student");

            migrationBuilder.DropIndex(
                name: "IX_Except_Info_Employ_UserFiles_InfoId",
                table: "Except_Info_Employ");

            migrationBuilder.DropIndex(
                name: "IX_Except_Info_Employ_facultystaff_InfoId",
                table: "Except_Info_Employ");

            migrationBuilder.DropColumn(
                name: "UserFiles_InfoId",
                table: "Except_Info_Student");

            migrationBuilder.DropColumn(
                name: "UserFiles_InfoId",
                table: "Except_Info_Employ");
        }
    }
}
