using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Health_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdNumber = table.Column<string>(nullable: true),
                    IsHot = table.Column<string>(nullable: true),
                    IsThroat = table.Column<string>(nullable: true),
                    IsWeak = table.Column<string>(nullable: true),
                    IsFamilyHot = table.Column<string>(nullable: true),
                    IsFamilyThroat = table.Column<string>(nullable: true),
                    IsFamilyWeakt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Health_Info", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "School_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(nullable: true),
                    SchoolCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Info", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UploadFile",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhysisticName = table.Column<string>(nullable: true),
                    Catalog = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_UploadFile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Student_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Health_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_Info_Health_Info_Health_InfoId",
                        column: x => x.Health_InfoId,
                        principalTable: "Health_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Station_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StationName = table.Column<string>(nullable: true),
                    StationCode = table.Column<string>(nullable: true),
                    School_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_Station_Info_School_Info_School_InfoId",
                        column: x => x.School_InfoId,
                        principalTable: "School_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facultystaff_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    station_Infoid = table.Column<int>(nullable: true),
                    station_InfoIdid = table.Column<int>(nullable: true),
                    Health_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facultystaff_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_facultystaff_Info_Health_Info_Health_InfoId",
                        column: x => x.Health_InfoId,
                        principalTable: "Health_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_facultystaff_Info_Station_Info_station_InfoIdid",
                        column: x => x.station_InfoIdid,
                        principalTable: "Station_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facultystaff_Info_Station_Info_station_Infoid",
                        column: x => x.station_Infoid,
                        principalTable: "Station_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grade_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(nullable: true),
                    GradeCode = table.Column<string>(nullable: true),
                    Station_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_Grade_Info_Station_Info_Station_InfoId",
                        column: x => x.Station_InfoId,
                        principalTable: "Station_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true),
                    ClassCode = table.Column<string>(nullable: true),
                    Grade_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_Class_Info_Grade_Info_Grade_InfoId",
                        column: x => x.Grade_InfoId,
                        principalTable: "Grade_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_Info_Grade_InfoId",
                table: "Class_Info",
                column: "Grade_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_facultystaff_Info_Health_InfoId",
                table: "facultystaff_Info",
                column: "Health_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_facultystaff_Info_station_InfoIdid",
                table: "facultystaff_Info",
                column: "station_InfoIdid");

            migrationBuilder.CreateIndex(
                name: "IX_facultystaff_Info_station_Infoid",
                table: "facultystaff_Info",
                column: "station_Infoid");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Info_Station_InfoId",
                table: "Grade_Info",
                column: "Station_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_Info_School_InfoId",
                table: "Station_Info",
                column: "School_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Info_Health_InfoId",
                table: "Student_Info",
                column: "Health_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class_Info");

            migrationBuilder.DropTable(
                name: "facultystaff_Info");

            migrationBuilder.DropTable(
                name: "Student_Info");

            migrationBuilder.DropTable(
                name: "UploadFile");

            migrationBuilder.DropTable(
                name: "Grade_Info");

            migrationBuilder.DropTable(
                name: "Health_Info");

            migrationBuilder.DropTable(
                name: "Station_Info");

            migrationBuilder.DropTable(
                name: "School_Info");
        }
    }
}
