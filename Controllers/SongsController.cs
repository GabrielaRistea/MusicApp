using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_App.Models;
using Music_App.Services.Interfaces;
using Music_App.DTOs;
using Music_App.Services;

namespace Music_App.Controllers;

public class SongsController : Controller
{
    private readonly ISongService _songService;
    private readonly IArtistService _artistService;
    private readonly IGenreService _genreService;
    public SongsController(ISongService songService, IArtistService artistService, IGenreService genreService)
    {
        _songService = songService;
        _artistService = artistService;
        _genreService = genreService;
    }

    public IActionResult Index(string searchSong)
    {
        var songs = _songService.GetAllSongs()
            .Select(s => mapSong(s)).ToList();
        var songartists = _songService.GetAllSongArtists();
        var songgenres = _songService.GetAllSongGenres();
        var albums = _songService.GetAllAlbums();
        var playlistsongs = _songService.GetAllPlaylistSongs();
        var reviews = _songService.GetAllReviews();
        ViewData["IdAlbum"] = new SelectList(albums, "Id", "Title");
        if (!String.IsNullOrEmpty(searchSong))
        {
            songs = songs.Where(s => s.Name !=  null ? s.Name.Contains(searchSong) : true).ToList();
        }

            return View(songs);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = _songService.GetSongById(id.Value);

        if (song == null)
        {
            return NotFound();
        }

        return View(mapSong(song));
    }

    public IActionResult Create()
    {
        var artists = _artistService.GetAllArtists();
        var genres = _genreService.GetAllGenres();
        var albums = _songService.GetAllAlbums();
        //var playlistsongs = _songService.GetAllPlaylistSongs();
        //var reviews = _songService.GetAllReviews();
        ViewData["IdAlbum"] = new SelectList(albums, "Id", "Title");
        ViewData["Artists"] = new MultiSelectList(artists, "Id", "Name");
        ViewData["Genres"] = new MultiSelectList(genres, "Id", "Type");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,IdAlbum,Name,Duration,ReleaseDate,Link, Artists, Genres")] SongDTO songDto)
    {
        var song = mapSong(songDto);
       
        _songService.AddSong(song);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = _songService.GetSongById(id.Value);
       
        if (_songService == null)
        {
            return NotFound();
        }
        var artists = _artistService.GetAllArtists();
        var genres = _genreService.GetAllGenres();
        var albums = _songService.GetAllAlbums();
        //var playlistsongs = _songService.GetAllPlaylistSongs();
        //var reviews = _songService.GetAllReviews();
        ViewData["IdAlbum"] = new SelectList(albums, "Id", "Title", song.IdAlbum);
        ViewData["Artists"] = new MultiSelectList(artists, "Id", "Name");
        ViewData["Genres"] = new MultiSelectList(genres, "Id", "Type");
        return View(mapSong(song));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,IdAlbum,Name,Duration,ReleaseDate,Link,Artists,Genres")] SongDTO songDto)
    {
        if (id != songDto.Id)
        {
            return NotFound();
        }

        var song = mapSong(songDto);

        //if (ModelState.IsValid)
        //{
        try
            {
                _songService.UpdateSong(song);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_songService.SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = _songService.GetSongById(id.Value);

        if (song == null)
        {
            return NotFound();
        }

        return View(mapSong(song));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var song = _songService.GetSongById(id);
        if (song != null)
        {
            _songService.DeleteSong(id);
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult SongGroupByAlbum(int albumId)
    {
        var song = _songService.GetAllSongsByAlbum(albumId).Select(s => mapSong(s)).ToList(); ;
        
        return View(song);
    }

    private SongDTO mapSong(Song s)
    {
       return new SongDTO()
        {
            Id = s.Id,
            IdAlbum = s.IdAlbum,
            Name = s.Name,
            Duration = s.Duration,
            ReleaseDate = s.ReleaseDate.ToUniversalTime(),
            Link = s.Link,
            Artists = s.SongArtists?.Select(sa => sa.Artist?.Id ?? 0).ToList() ?? [],
            ArtistNames = s.SongArtists?.Select(sa => sa.Artist?.Name ?? "").ToList() ?? [],
            Genres = s.SongGenres?.Select(sg => sg.Genre?.Id ?? 0).ToList() ?? [],
            GenreTypes = s.SongGenres?.Select(sg => sg.Genre?.Type ?? "").ToList() ?? [],
        };
    }

    private Song mapSong(SongDTO songDto)
    {
        return new Song()
        {
            Id = songDto.Id,
            IdAlbum = songDto.IdAlbum,
            Name = songDto.Name,
            Duration = songDto.Duration,
            ReleaseDate = songDto.ReleaseDate.ToUniversalTime(),
            Link = songDto.Link,
            SongArtists = songDto.Artists.Select(a => new SongArtist() { IdArtist = a }).ToList(),
            SongGenres = songDto.Genres.Select(g => new SongGenre() { IdGenre = g }).ToList(),
        };
    }
}


