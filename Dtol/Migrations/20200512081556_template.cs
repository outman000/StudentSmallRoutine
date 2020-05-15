using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class template : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsTianJin",
                table: "Student_DayandNight_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotComeJinReason",
                table: "Student_DayandNight_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tag",
                table: "facultystaff_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Template_Employment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolCode = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true),
                    DepartCode = table.Column<string>(nullable: true),
                    DepartName = table.Column<string>(nullable: true),
                    StaffCode = table.Column<string>(nullable: true),
                    StaffName = table.Column<string>(nullable: true),
                    ShouldComeSchoolCount = table.Column<int>(nullable: true),
                    ActualComeSchoolCount = table.Column<int>(nullable: true),
                    ComeSchoolHotCount = table.Column<int>(nullable: true),
                    NotComeSchoolCount = table.Column<int>(nullable: true),
                    NotComeSchoolByOutCount = table.Column<int>(nullable: true),
                    NotComeSchoolByHotCount = table.Column<int>(nullable: true),
                    NotComeSchoolByOtherCount = table.Column<int>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template_Employment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Template_Student",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolCode = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true),
                    GradeCode = table.Column<string>(nullable: true),
                    GradeName = table.Column<string>(nullable: true),
                    ClassCode = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    ShouldComeSchoolCount = table.Column<int>(nullable: true),
                    ActualComeSchoolCount = table.Column<int>(nullable: true),
                    ComeSchoolHotCount = table.Column<int>(nullable: true),
                    NotComeSchoolCount = table.Column<int>(nullable: true),
                    NotComeSchoolByOutCount = table.Column<int>(nullable: true),
                    NotComeSchoolByHotCount = table.Column<int>(nullable: true),
                    NotComeSchoolByOtherCount = table.Column<int>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template_Student", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Template_Employment");

            migrationBuilder.DropTable(
                name: "Template_Student");

            migrationBuilder.DropColumn(
                name: "IsTianJin",
                table: "Student_DayandNight_Info");

            migrationBuilder.DropColumn(
                name: "NotComeJinReason",
                table: "Student_DayandNight_Info");

            migrationBuilder.DropColumn(
                name: "tag",
                table: "facultystaff_Info");
        }
    }
}
