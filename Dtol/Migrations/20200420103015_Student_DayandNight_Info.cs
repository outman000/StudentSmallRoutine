using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class Student_DayandNight_Info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_DayandNight_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GradeName = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    Temperature = table.Column<string>(nullable: true),
                    IsComeSchool = table.Column<string>(nullable: true),
                    AddTimeInterval = table.Column<string>(nullable: true),
                    AddCreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_DayandNight_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_DayandNight_Info");
        }
    }
}
