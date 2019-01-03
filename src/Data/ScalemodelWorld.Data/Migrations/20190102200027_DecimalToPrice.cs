using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScalemodelWorld.Data.Migrations
{
    public partial class DecimalToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 500, nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nickname = table.Column<string>(nullable: true),
                    ClubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
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
                    Purchased = table.Column<bool>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Aftermarkets_User_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: true),
                    BoxPicture = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_AvailableScalemodels_User_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_User_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    GivenSold = table.Column<string>(nullable: true),
                    PicturesLink = table.Column<string>(nullable: true),
                    ForumsLink = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    FinishingDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_CompletedScalemodels_User_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CategoryId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Consumables_User_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: true),
                    BoxPicture = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_StartedScalemodels_User_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Description = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Tools_User_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Userd = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    BoxPicture = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_WishScalemodels_User_UserId",
                        column: x => x.UserId,
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
                name: "IX_Aftermarkets_OwnerId1",
                table: "Aftermarkets",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableAftermarket_AvailableScalemodelId",
                table: "AvailableAftermarket",
                column: "AvailableScalemodelId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableScalemodels_ManifacturerId",
                table: "AvailableScalemodels",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableScalemodels_OwnerId1",
                table: "AvailableScalemodels",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Book_OwnerId1",
                table: "Book",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClubModelshows_ModelshowId",
                table: "ClubModelshows",
                column: "ModelshowId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedAftermarkets_CompletedScalemodelId",
                table: "CompletedAftermarkets",
                column: "CompletedScalemodelId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedScalemodels_ManifacturerId",
                table: "CompletedScalemodels",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedScalemodels_OwnerId1",
                table: "CompletedScalemodels",
                column: "OwnerId1");

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
                name: "IX_Consumables_OwnerId1",
                table: "Consumables",
                column: "OwnerId1");

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
                name: "IX_StartedScalemodels_OwnerId1",
                table: "StartedScalemodels",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ManifacturerId",
                table: "Tools",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_OwnerId1",
                table: "Tools",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_ClubId",
                table: "User",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserModelshows_ModelshowId",
                table: "UserModelshows",
                column: "ModelshowId");

            migrationBuilder.CreateIndex(
                name: "IX_WishScalemodels_ManifacturerId",
                table: "WishScalemodels",
                column: "ManifacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_WishScalemodels_UserId",
                table: "WishScalemodels",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AvailableAftermarket");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "ClubModelshows");

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
                name: "UserModelshows");

            migrationBuilder.DropTable(
                name: "WishScalemodels");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AvailableScalemodels");

            migrationBuilder.DropTable(
                name: "CompletedScalemodels");

            migrationBuilder.DropTable(
                name: "ConsumableCategories");

            migrationBuilder.DropTable(
                name: "Aftermarkets");

            migrationBuilder.DropTable(
                name: "StartedScalemodels");

            migrationBuilder.DropTable(
                name: "ModelShows");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Manifacturers");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
