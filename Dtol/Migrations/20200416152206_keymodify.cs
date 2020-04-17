using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class keymodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Station_Infoid",
                table: "Class_Info",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Info_Station_Info_Station_Infoid",
                table: "Class_Info");

            migrationBuilder.DropIndex(
                name: "IX_Class_Info_Station_Infoid",
                table: "Class_Info");

            migrationBuilder.DropColumn(
                name: "Station_Infoid",
                table: "Class_Info");
        }
    }
}
