using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class userright : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Rights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RightsName = table.Column<string>(nullable: true),
                    RightsValue = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Rights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Rights");
        }
    }
}
