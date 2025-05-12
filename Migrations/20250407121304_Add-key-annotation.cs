using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_App.Migrations
{
    /// <inheritdoc />
    public partial class Addkeyannotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistIdArtist",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserIdUser",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlists_PlaylistIdPlaylist",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Songs_SongIdSong",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserIdUser",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artists_ArtistIdArtist",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Songs_SongIdSong",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Genres_GenreIdGenre",
                table: "SongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Songs_SongIdSong",
                table: "SongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumIdAlbum",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionIdSub",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubscriptionIdSub",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumIdAlbum",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_SongGenres_GenreIdGenre",
                table: "SongGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongGenres_SongIdSong",
                table: "SongGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongArtists_ArtistIdArtist",
                table: "SongArtists");

            migrationBuilder.DropIndex(
                name: "IX_SongArtists_SongIdSong",
                table: "SongArtists");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserIdUser",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_PlaylistIdPlaylist",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_SongIdSong",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_UserIdUser",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistIdArtist",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "SubscriptionIdSub",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AlbumIdAlbum",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "GenreIdGenre",
                table: "SongGenres");

            migrationBuilder.DropColumn(
                name: "SongIdSong",
                table: "SongGenres");

            migrationBuilder.DropColumn(
                name: "ArtistIdArtist",
                table: "SongArtists");

            migrationBuilder.DropColumn(
                name: "SongIdSong",
                table: "SongArtists");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PlaylistIdPlaylist",
                table: "PlaylistSongs");

            migrationBuilder.DropColumn(
                name: "SongIdSong",
                table: "PlaylistSongs");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "ArtistIdArtist",
                table: "Albums");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdSub",
                table: "Users",
                column: "IdSub");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_IdAlbum",
                table: "Songs",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_IdGenre",
                table: "SongGenres",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_IdSong",
                table: "SongGenres",
                column: "IdSong");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtists_IdArtist",
                table: "SongArtists",
                column: "IdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtists_IdSong",
                table: "SongArtists",
                column: "IdSong");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdSong",
                table: "Reviews",
                column: "IdSong");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdUser",
                table: "Reviews",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_IdPlaylist",
                table: "PlaylistSongs",
                column: "IdPlaylist");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_IdSong",
                table: "PlaylistSongs",
                column: "IdSong");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_IdUser",
                table: "Playlists",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_IdArtist",
                table: "Albums",
                column: "IdArtist");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_IdArtist",
                table: "Albums",
                column: "IdArtist",
                principalTable: "Artists",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_IdUser",
                table: "Playlists",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlists_IdPlaylist",
                table: "PlaylistSongs",
                column: "IdPlaylist",
                principalTable: "Playlists",
                principalColumn: "IdPlaylist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Songs_IdSong",
                table: "PlaylistSongs",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Songs_IdSong",
                table: "Reviews",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_IdUser",
                table: "Reviews",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artists_IdArtist",
                table: "SongArtists",
                column: "IdArtist",
                principalTable: "Artists",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Songs_IdSong",
                table: "SongArtists",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Genres_IdGenre",
                table: "SongGenres",
                column: "IdGenre",
                principalTable: "Genres",
                principalColumn: "IdGenre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Songs_IdSong",
                table: "SongGenres",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs",
                column: "IdAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscriptions_IdSub",
                table: "Users",
                column: "IdSub",
                principalTable: "Subscriptions",
                principalColumn: "IdSub",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_IdArtist",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_IdUser",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlists_IdPlaylist",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Songs_IdSong",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Songs_IdSong",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_IdUser",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artists_IdArtist",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Songs_IdSong",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Genres_IdGenre",
                table: "SongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Songs_IdSong",
                table: "SongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_IdAlbum",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscriptions_IdSub",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdSub",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Songs_IdAlbum",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_SongGenres_IdGenre",
                table: "SongGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongGenres_IdSong",
                table: "SongGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongArtists_IdArtist",
                table: "SongArtists");

            migrationBuilder.DropIndex(
                name: "IX_SongArtists_IdSong",
                table: "SongArtists");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_IdSong",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_IdUser",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_IdPlaylist",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_IdSong",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_IdUser",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Albums_IdArtist",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionIdSub",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlbumIdAlbum",
                table: "Songs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreIdGenre",
                table: "SongGenres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongIdSong",
                table: "SongGenres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistIdArtist",
                table: "SongArtists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongIdSong",
                table: "SongArtists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistIdPlaylist",
                table: "PlaylistSongs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongIdSong",
                table: "PlaylistSongs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "Playlists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistIdArtist",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionIdSub",
                table: "Users",
                column: "SubscriptionIdSub");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumIdAlbum",
                table: "Songs",
                column: "AlbumIdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_GenreIdGenre",
                table: "SongGenres",
                column: "GenreIdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_SongIdSong",
                table: "SongGenres",
                column: "SongIdSong");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtists_ArtistIdArtist",
                table: "SongArtists",
                column: "ArtistIdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtists_SongIdSong",
                table: "SongArtists",
                column: "SongIdSong");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserIdUser",
                table: "Reviews",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_PlaylistIdPlaylist",
                table: "PlaylistSongs",
                column: "PlaylistIdPlaylist");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_SongIdSong",
                table: "PlaylistSongs",
                column: "SongIdSong");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserIdUser",
                table: "Playlists",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistIdArtist",
                table: "Albums",
                column: "ArtistIdArtist");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistIdArtist",
                table: "Albums",
                column: "ArtistIdArtist",
                principalTable: "Artists",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserIdUser",
                table: "Playlists",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlists_PlaylistIdPlaylist",
                table: "PlaylistSongs",
                column: "PlaylistIdPlaylist",
                principalTable: "Playlists",
                principalColumn: "IdPlaylist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Songs_SongIdSong",
                table: "PlaylistSongs",
                column: "SongIdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserIdUser",
                table: "Reviews",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artists_ArtistIdArtist",
                table: "SongArtists",
                column: "ArtistIdArtist",
                principalTable: "Artists",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Songs_SongIdSong",
                table: "SongArtists",
                column: "SongIdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Genres_GenreIdGenre",
                table: "SongGenres",
                column: "GenreIdGenre",
                principalTable: "Genres",
                principalColumn: "IdGenre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Songs_SongIdSong",
                table: "SongGenres",
                column: "SongIdSong",
                principalTable: "Songs",
                principalColumn: "IdSong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumIdAlbum",
                table: "Songs",
                column: "AlbumIdAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionIdSub",
                table: "Users",
                column: "SubscriptionIdSub",
                principalTable: "Subscriptions",
                principalColumn: "IdSub",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
