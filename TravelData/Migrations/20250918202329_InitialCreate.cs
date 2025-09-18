using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Languages = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Travelers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PassportNumber = table.Column<string>(type: "TEXT", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travelers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdventurePackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    DurationInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    GuideId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventurePackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdventurePackages_Guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelerProfiles",
                columns: table => new
                {
                    TravelerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MedicalNotes = table.Column<string>(type: "TEXT", nullable: false),
                    Preferences = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerProfiles", x => x.TravelerId);
                    table.ForeignKey(
                        name: "FK_TravelerProfiles_Travelers_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Travelers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelerAdventures",
                columns: table => new
                {
                    TravelerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdventurePackageId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerAdventures", x => new { x.TravelerId, x.AdventurePackageId });
                    table.ForeignKey(
                        name: "FK_TravelerAdventures_AdventurePackages_AdventurePackageId",
                        column: x => x.AdventurePackageId,
                        principalTable: "AdventurePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelerAdventures_Travelers_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Travelers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventurePackages_GuideId",
                table: "AdventurePackages",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerAdventures_AdventurePackageId",
                table: "TravelerAdventures",
                column: "AdventurePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Travelers_Email",
                table: "Travelers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travelers_PassportNumber",
                table: "Travelers",
                column: "PassportNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelerAdventures");

            migrationBuilder.DropTable(
                name: "TravelerProfiles");

            migrationBuilder.DropTable(
                name: "AdventurePackages");

            migrationBuilder.DropTable(
                name: "Travelers");

            migrationBuilder.DropTable(
                name: "Guides");
        }
    }
}
