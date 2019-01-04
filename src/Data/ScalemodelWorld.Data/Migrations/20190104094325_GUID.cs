using Microsoft.EntityFrameworkCore.Migrations;

namespace ScalemodelWorld.Data.Migrations
{
    public partial class GUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableScalemodels_User_OwnerId1",
                table: "AvailableScalemodels");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedScalemodels_User_OwnerId1",
                table: "CompletedScalemodels");

            migrationBuilder.DropForeignKey(
                name: "FK_StartedScalemodels_User_OwnerId1",
                table: "StartedScalemodels");

            migrationBuilder.DropIndex(
                name: "IX_StartedScalemodels_OwnerId1",
                table: "StartedScalemodels");

            migrationBuilder.DropIndex(
                name: "IX_CompletedScalemodels_OwnerId1",
                table: "CompletedScalemodels");

            migrationBuilder.DropIndex(
                name: "IX_AvailableScalemodels_OwnerId1",
                table: "AvailableScalemodels");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "StartedScalemodels");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "CompletedScalemodels");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "AvailableScalemodels");

            migrationBuilder.AlterColumn<string>(
                name: "Userd",
                table: "WishScalemodels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "StartedScalemodels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "CompletedScalemodels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "AvailableScalemodels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_StartedScalemodels_OwnerId",
                table: "StartedScalemodels",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedScalemodels_OwnerId",
                table: "CompletedScalemodels",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableScalemodels_OwnerId",
                table: "AvailableScalemodels",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableScalemodels_User_OwnerId",
                table: "AvailableScalemodels",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedScalemodels_User_OwnerId",
                table: "CompletedScalemodels",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StartedScalemodels_User_OwnerId",
                table: "StartedScalemodels",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableScalemodels_User_OwnerId",
                table: "AvailableScalemodels");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedScalemodels_User_OwnerId",
                table: "CompletedScalemodels");

            migrationBuilder.DropForeignKey(
                name: "FK_StartedScalemodels_User_OwnerId",
                table: "StartedScalemodels");

            migrationBuilder.DropIndex(
                name: "IX_StartedScalemodels_OwnerId",
                table: "StartedScalemodels");

            migrationBuilder.DropIndex(
                name: "IX_CompletedScalemodels_OwnerId",
                table: "CompletedScalemodels");

            migrationBuilder.DropIndex(
                name: "IX_AvailableScalemodels_OwnerId",
                table: "AvailableScalemodels");

            migrationBuilder.AlterColumn<int>(
                name: "Userd",
                table: "WishScalemodels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "StartedScalemodels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "StartedScalemodels",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "CompletedScalemodels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "CompletedScalemodels",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "AvailableScalemodels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "AvailableScalemodels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StartedScalemodels_OwnerId1",
                table: "StartedScalemodels",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedScalemodels_OwnerId1",
                table: "CompletedScalemodels",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableScalemodels_OwnerId1",
                table: "AvailableScalemodels",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableScalemodels_User_OwnerId1",
                table: "AvailableScalemodels",
                column: "OwnerId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedScalemodels_User_OwnerId1",
                table: "CompletedScalemodels",
                column: "OwnerId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StartedScalemodels_User_OwnerId1",
                table: "StartedScalemodels",
                column: "OwnerId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
