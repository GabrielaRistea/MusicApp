using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_App.Migrations
{
    /// <inheritdoc />
    public partial class renameIdCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdSub",
                table: "Subscriptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdSong",
                table: "Songs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdReview",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPlaylist",
                table: "Playlists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdGenre",
                table: "Genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdArtist",
                table: "Artists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdAlbum",
                table: "Albums",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subscriptions",
                newName: "IdSub");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Songs",
                newName: "IdSong");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "IdReview");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Playlists",
                newName: "IdPlaylist");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "IdGenre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artists",
                newName: "IdArtist");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Albums",
                newName: "IdAlbum");
        }
    }
}
