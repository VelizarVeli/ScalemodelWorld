using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScalemodelWorld.Data.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ConsumableCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manifacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aftermarkets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FactoryNumber = table.Column<string>(nullable: true),
                    ManifacturerId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Purchased = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aftermarkets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aftermarkets_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableScalemodels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scale = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ManifacturerId = table.Column<int>(nullable: false),
                    FactoryNumber = table.Column<string>(nullable: false),
                    CombinesWith = table.Column<string>(nullable: true),
                    BestCompanyOffer = table.Column<string>(nullable: true),
                    InfoHowTo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableScalemodels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableScalemodels_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedScalemodels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scale = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ManifacturerId = table.Column<int>(nullable: false),
                    FactoryNumber = table.Column<string>(nullable: false),
                    CombinesWith = table.Column<string>(nullable: true),
                    BestCompanyOffer = table.Column<string>(nullable: true),
                    InfoHowTo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    GivenSold = table.Column<string>(nullable: true),
                    PicturesLink = table.Column<string>(nullable: true),
                    ForumsLink = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    FinishingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedScalemodels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedScalemodels_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ManifacturerId = table.Column<int>(nullable: false),
                    ManifacturerNumber = table.Column<string>(nullable: true),
                    Coverage = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    DateOfPurchase = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumables_ConsumableCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ConsumableCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumables_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelShows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scale = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ManifacturerId = table.Column<int>(nullable: false),
                    FactoryNumber = table.Column<string>(nullable: false),
                    CombinesWith = table.Column<string>(nullable: true),
                    BestCompanyOffer = table.Column<string>(nullable: true),
                    InfoHowTo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    ModelShowName = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelShows_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartedScalemodels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scale = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ManifacturerId = table.Column<int>(nullable: false),
                    FactoryNumber = table.Column<string>(nullable: false),
                    CombinesWith = table.Column<string>(nullable: true),
                    BestCompanyOffer = table.Column<string>(nullable: true),
                    InfoHowTo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartedScalemodels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartedScalemodels_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ManifacturerId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tools_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishScalemodels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scale = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ManifacturerId = table.Column<int>(nullable: false),
                    FactoryNumber = table.Column<string>(nullable: false),
                    CombinesWith = table.Column<string>(nullable: true),
                    BestCompanyOffer = table.Column<string>(nullable: true),
                    InfoHowTo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishScalemodels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishScalemodels_Manifacturers_ManifacturerId",
                        column: x => x.ManifacturerId,
                        principalTable: "Manifacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableAftermarket",
                columns: table => new
                {
                    AvailableScalemodelId = table.Column<int>(nullable: false),
                    AvailableAftermarketId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableAftermarket", x => new { x.AvailableAftermarketId, x.AvailableScalemodelId });
                    table.ForeignKey(
                        name: "FK_AvailableAftermarket_Aftermarkets_AvailableAftermarketId",
                        column: x => x.AvailableAftermarketId,
                        principalTable: "Aftermarkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvailableAftermarket_AvailableScalemodels_AvailableScalemodelId",
                        column: x => x.AvailableScalemodelId,
                        principalTable: "AvailableScalemodels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompletedAftermarkets",
                columns: table => new
                {
                    CompletedScalemodelId = table.Column<int>(nullable: false),
                    CompletedAftermarketId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedAftermarkets", x => new { x.CompletedAftermarketId, x.CompletedScalemodelId });
                    table.ForeignKey(
                        name: "FK_CompletedAftermarkets_Aftermarkets_CompletedAftermarketId",
                        column: x => x.CompletedAftermarketId,
                        principalTable: "Aftermarkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompletedAftermarkets_CompletedScalemodels_CompletedScalemodelId",
                        column: x => x.CompletedScalemodelId,
                        principalTable: "CompletedScalemodels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompletedScalemodelShowParticipations",
                columns: table => new
                {
                    ModelshowId = table.Column<int>(nullable: false),
                    CompletedScalemodelId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedScalemodelShowParticipations", x => new { x.CompletedScalemodelId, x.ModelshowId });
                    table.ForeignKey(
                        name: "FK_CompletedScalemodelShowParticipations_CompletedScalemodels_CompletedScalemodelId",
                        column: x => x.CompletedScalemodelId,
                        principalTable: "CompletedScalemodels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompletedScalemodelShowParticipations_ModelShows_ModelshowId",
                        column: x => x.ModelshowId,
                        principalTable: "ModelShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelShowCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelShowId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelShowCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelShowCategory_ModelShows_ModelShowId",
                        column: x => x.ModelShowId,
                        principalTable: "ModelShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartedAftermarkets",
                columns: table => new
                {
                    StartedScalemodelId = table.Column<int>(nullable: false),
                    StartedAftermarketId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartedAftermarkets", x => new { x.StartedAftermarketId, x.StartedScalemodelId });
                    table.ForeignKey(
                        name: "FK_StartedAftermarkets_Aftermarkets_StartedAftermarketId",
                        column: x => x.StartedAftermarketId,
                        principalTable: "Aftermarkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StartedAftermarkets_StartedScalemodels_StartedScalemodelId",
                        column: x => x.StartedScalemodelId,
                        principalTable: "StartedScalemodels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aftermarkets_ManifacturerId",
                table: "Aftermarkets",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableAftermarket_AvailableScalemodelId",
                table: "AvailableAftermarket",
                column: "AvailableScalemodelId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableScalemodels_ManifacturerId",
                table: "AvailableScalemodels",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedAftermarkets_CompletedScalemodelId",
                table: "CompletedAftermarkets",
                column: "CompletedScalemodelId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedScalemodels_ManifacturerId",
                table: "CompletedScalemodels",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedScalemodelShowParticipations_ModelshowId",
                table: "CompletedScalemodelShowParticipations",
                column: "ModelshowId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_CategoryId",
                table: "Consumables",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_ManifacturerId",
                table: "Consumables",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelShowCategory_ModelShowId",
                table: "ModelShowCategory",
                column: "ModelShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelShows_ManifacturerId",
                table: "ModelShows",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_StartedAftermarkets_StartedScalemodelId",
                table: "StartedAftermarkets",
                column: "StartedScalemodelId");

            migrationBuilder.CreateIndex(
                name: "IX_StartedScalemodels_ManifacturerId",
                table: "StartedScalemodels",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ManifacturerId",
                table: "Tools",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_WishScalemodels_ManifacturerId",
                table: "WishScalemodels",
                column: "ManifacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AvailableAftermarket");

            migrationBuilder.DropTable(
                name: "CompletedAftermarkets");

            migrationBuilder.DropTable(
                name: "CompletedScalemodelShowParticipations");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "ModelShowCategory");

            migrationBuilder.DropTable(
                name: "StartedAftermarkets");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "WishScalemodels");

            migrationBuilder.DropTable(
                name: "AvailableScalemodels");

            migrationBuilder.DropTable(
                name: "CompletedScalemodels");

            migrationBuilder.DropTable(
                name: "ConsumableCategories");

            migrationBuilder.DropTable(
                name: "ModelShows");

            migrationBuilder.DropTable(
                name: "Aftermarkets");

            migrationBuilder.DropTable(
                name: "StartedScalemodels");

            migrationBuilder.DropTable(
                name: "Manifacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
