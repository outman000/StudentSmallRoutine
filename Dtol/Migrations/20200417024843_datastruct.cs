using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class datastruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassManager_Relate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Class_InfoId = table.Column<int>(nullable: true),
                    facultystaff_InfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassManager_Relate", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClassManager_Relate_Class_Info_Class_InfoId",
                        column: x => x.Class_InfoId,
                        principalTable: "Class_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassManager_Relate_facultystaff_Info_facultystaff_InfoId",
                        column: x => x.facultystaff_InfoId,
                        principalTable: "facultystaff_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassManager_Relate_Class_InfoId",
                table: "ClassManager_Relate",
                column: "Class_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassManager_Relate_facultystaff_InfoId",
                table: "ClassManager_Relate",
                column: "facultystaff_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassManager_Relate");
        }
    }
}
