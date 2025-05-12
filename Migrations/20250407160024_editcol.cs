using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_App.Migrations
{
    /// <inheritdoc />
    public partial class editcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "IdAlbum",
                table: "Songs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs",
                column: "IdAlbum",
                principalTable: "Albums",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "IdAlbum",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs",
                column: "IdAlbum",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
