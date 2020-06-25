using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineFight.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Attaque = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Pv = table.Column<int>(nullable: false),
                    PvMax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WinnerId = table.Column<int>(nullable: true),
                    LoserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combats_Personnages_LoserId",
                        column: x => x.LoserId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combats_Personnages_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Degat = table.Column<int>(nullable: false),
                    Turn = table.Column<int>(nullable: false),
                    personnageACtifId = table.Column<int>(nullable: true),
                    personnagePassifId = table.Column<int>(nullable: true),
                    CombatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historiques_Personnages_personnageACtifId",
                        column: x => x.personnageACtifId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historiques_Personnages_personnagePassifId",
                        column: x => x.personnagePassifId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combats_LoserId",
                table: "Combats",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Combats_WinnerId",
                table: "Combats",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_personnageACtifId",
                table: "Historiques",
                column: "personnageACtifId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_personnagePassifId",
                table: "Historiques",
                column: "personnagePassifId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combats");

            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Personnages");
        }
    }
}
