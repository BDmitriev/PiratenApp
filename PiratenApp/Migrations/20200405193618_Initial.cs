using Microsoft.EntityFrameworkCore.Migrations;

namespace PiratenApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piraten",
                columns: table => new
                {
                    PiratId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<string>(nullable: false),
                    ZIP = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Motiv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piraten", x => x.PiratId);
                });

            migrationBuilder.CreateTable(
                name: "Schiffe",
                columns: table => new
                {
                    SchiffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchiffName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schiffe", x => x.SchiffId);
                });

            migrationBuilder.CreateTable(
                name: "PiratSchiffe",
                columns: table => new
                {
                    PSID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiratId = table.Column<int>(nullable: false),
                    SchiffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiratSchiffe", x => x.PSID);
                    table.ForeignKey(
                        name: "FK_PiratSchiffe_Piraten_PiratId",
                        column: x => x.PiratId,
                        principalTable: "Piraten",
                        principalColumn: "PiratId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiratSchiffe_Schiffe_SchiffId",
                        column: x => x.SchiffId,
                        principalTable: "Schiffe",
                        principalColumn: "SchiffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PiratSchiffe_PiratId",
                table: "PiratSchiffe",
                column: "PiratId");

            migrationBuilder.CreateIndex(
                name: "IX_PiratSchiffe_SchiffId",
                table: "PiratSchiffe",
                column: "SchiffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PiratSchiffe");

            migrationBuilder.DropTable(
                name: "Piraten");

            migrationBuilder.DropTable(
                name: "Schiffe");
        }
    }
}
