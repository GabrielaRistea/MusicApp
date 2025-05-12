using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Music_App.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    IdArtist = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ArtistImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.IdArtist);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    IdGenre = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.IdGenre);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    IdSub = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.IdSub);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdArtist = table.Column<int>(type: "integer", nullable: false),
                    ArtistIdArtist = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistIdArtist",
                        column: x => x.ArtistIdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    ProfilPicture = table.Column<byte[]>(type: "bytea", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    IdSub = table.Column<int>(type: "integer", nullable: false),
                    SubscriptionIdSub = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_SubscriptionIdSub",
                        column: x => x.SubscriptionIdSub,
                        principalTable: "Subscriptions",
                        principalColumn: "IdSub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    IdSong = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    IdAlbum = table.Column<int>(type: "integer", nullable: false),
                    AlbumIdAlbum = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.IdSong);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum");
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    IdPlaylist = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    UserIdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.IdPlaylist);
                    table.ForeignKey(
                        name: "FK_Playlists_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    IdReview = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comm = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    IdSong = table.Column<int>(type: "integer", nullable: false),
                    UserIdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.IdReview);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongArtists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSong = table.Column<int>(type: "integer", nullable: false),
                    IdArtist = table.Column<int>(type: "integer", nullable: false),
                    SongIdSong = table.Column<int>(type: "integer", nullable: false),
                    ArtistIdArtist = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongArtists_Artists_ArtistIdArtist",
                        column: x => x.ArtistIdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongArtists_Songs_SongIdSong",
                        column: x => x.SongIdSong,
                        principalTable: "Songs",
                        principalColumn: "IdSong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSong = table.Column<int>(type: "integer", nullable: false),
                    IdGenre = table.Column<int>(type: "integer", nullable: false),
                    SongIdSong = table.Column<int>(type: "integer", nullable: false),
                    GenreIdGenre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongGenres_Genres_GenreIdGenre",
                        column: x => x.GenreIdGenre,
                        principalTable: "Genres",
                        principalColumn: "IdGenre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongGenres_Songs_SongIdSong",
                        column: x => x.SongIdSong,
                        principalTable: "Songs",
                        principalColumn: "IdSong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPlaylist = table.Column<int>(type: "integer", nullable: false),
                    IdSong = table.Column<int>(type: "integer", nullable: false),
                    PlaylistIdPlaylist = table.Column<int>(type: "integer", nullable: false),
                    SongIdSong = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistSongs_Playlists_PlaylistIdPlaylist",
                        column: x => x.PlaylistIdPlaylist,
                        principalTable: "Playlists",
                        principalColumn: "IdPlaylist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSongs_Songs_SongIdSong",
                        column: x => x.SongIdSong,
                        principalTable: "Songs",
                        principalColumn: "IdSong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistIdArtist",
                table: "Albums",
                column: "ArtistIdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserIdUser",
                table: "Playlists",
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
                name: "IX_Reviews_UserIdUser",
                table: "Reviews",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtists_ArtistIdArtist",
                table: "SongArtists",
                column: "ArtistIdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtists_SongIdSong",
                table: "SongArtists",
                column: "SongIdSong");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_GenreIdGenre",
                table: "SongGenres",
                column: "GenreIdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_SongIdSong",
                table: "SongGenres",
                column: "SongIdSong");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumIdAlbum",
                table: "Songs",
                column: "AlbumIdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionIdSub",
                table: "Users",
                column: "SubscriptionIdSub");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistSongs");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SongArtists");

            migrationBuilder.DropTable(
                name: "SongGenres");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
