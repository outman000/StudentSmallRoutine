using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class deoarttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Depart_Infoid",
                table: "Station_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Depart_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartName = table.Column<string>(nullable: true),
                    DepartCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depart_Info", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Station_Info_Depart_Infoid",
                table: "Station_Info",
                column: "Depart_Infoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Info_Depart_Info_Depart_Infoid",
                table: "Station_Info",
                column: "Depart_Infoid",
                principalTable: "Depart_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_Info_Depart_Info_Depart_Infoid",
                table: "Station_Info");

            migrationBuilder.DropTable(
                name: "Depart_Info");

            migrationBuilder.DropIndex(
                name: "IX_Station_Info_Depart_Infoid",
                table: "Station_Info");

            migrationBuilder.DropColumn(
                name: "Depart_Infoid",
                table: "Station_Info");
        }
    }
}
