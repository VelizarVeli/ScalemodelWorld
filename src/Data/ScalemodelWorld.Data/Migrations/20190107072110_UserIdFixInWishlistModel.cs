using Microsoft.EntityFrameworkCore.Migrations;

namespace ScalemodelWorld.Data.Migrations
{
    public partial class UserIdFixInWishlistModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Userd",
                table: "WishScalemodels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Userd",
                table: "WishScalemodels",
                nullable: true);
        }
    }
}
