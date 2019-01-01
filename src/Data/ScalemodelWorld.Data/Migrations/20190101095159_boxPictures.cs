using Microsoft.EntityFrameworkCore.Migrations;

namespace ScalemodelWorld.Data.Migrations
{
    public partial class boxPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoxPicture",
                table: "WishScalemodels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoxPicture",
                table: "StartedScalemodels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoxPicture",
                table: "AvailableScalemodels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxPicture",
                table: "WishScalemodels");

            migrationBuilder.DropColumn(
                name: "BoxPicture",
                table: "StartedScalemodels");

            migrationBuilder.DropColumn(
                name: "BoxPicture",
                table: "AvailableScalemodels");
        }
    }
}
