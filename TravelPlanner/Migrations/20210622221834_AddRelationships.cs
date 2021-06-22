using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlanner.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationMedias",
                columns: table => new
                {
                    LocationMediaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: false),
                    Src = table.Column<string>(nullable: false),
                    MediaType = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMedias", x => x.LocationMediaId);
                    table.ForeignKey(
                        name: "FK_LocationMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTripLikes",
                columns: table => new
                {
                    UserTripLikeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTripLikes", x => x.UserTripLikeId);
                    table.ForeignKey(
                        name: "FK_UserTripLikes_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTripLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripLocationPlans",
                columns: table => new
                {
                    TripLocationPlanId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    TripId = table.Column<int>(nullable: false),
                    LocationMediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripLocationPlans", x => x.TripLocationPlanId);
                    table.ForeignKey(
                        name: "FK_TripLocationPlans_LocationMedias_LocationMediaId",
                        column: x => x.LocationMediaId,
                        principalTable: "LocationMedias",
                        principalColumn: "LocationMediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripLocationPlans_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationMedias_UserId",
                table: "LocationMedias",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripLocationPlans_LocationMediaId",
                table: "TripLocationPlans",
                column: "LocationMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_TripLocationPlans_TripId",
                table: "TripLocationPlans",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTripLikes_TripId",
                table: "UserTripLikes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTripLikes_UserId",
                table: "UserTripLikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripLocationPlans");

            migrationBuilder.DropTable(
                name: "UserTripLikes");

            migrationBuilder.DropTable(
                name: "LocationMedias");
        }
    }
}
