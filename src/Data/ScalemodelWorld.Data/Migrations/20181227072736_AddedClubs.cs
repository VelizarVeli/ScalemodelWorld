using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScalemodelWorld.Data.Migrations
{
    public partial class AddedClubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FoundationDate = table.Column<DateTime>(nullable: false),
                    FoundationPlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModelshows",
                columns: table => new
                {
                    ParticipantId = table.Column<string>(nullable: false),
                    ModelshowId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModelshows", x => new { x.ParticipantId, x.ModelshowId });
                    table.UniqueConstraint("AK_UserModelshows_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModelshows_ModelShows_ModelshowId",
                        column: x => x.ModelshowId,
                        principalTable: "ModelShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserModelshows_User_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubModelshows",
                columns: table => new
                {
                    ClubId = table.Column<int>(nullable: false),
                    ModelshowId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubModelshows", x => new { x.ClubId, x.ModelshowId });
                    table.UniqueConstraint("AK_ClubModelshows_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubModelshows_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubModelshows_ModelShows_ModelshowId",
                        column: x => x.ModelshowId,
                        principalTable: "ModelShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ClubId",
                table: "User",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubModelshows_ModelshowId",
                table: "ClubModelshows",
                column: "ModelshowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModelshows_ModelshowId",
                table: "UserModelshows",
                column: "ModelshowId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Clubs_ClubId",
                table: "User",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Clubs_ClubId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ClubModelshows");

            migrationBuilder.DropTable(
                name: "UserModelshows");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_User_ClubId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "User");
        }
    }
}
