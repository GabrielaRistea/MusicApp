using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.DTOs;
using Music_App.Models;
using Music_App.Services;
using Music_App.Services.Interfaces;

namespace Music_App.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;
       // private readonly IArtistService _artistService;
        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
            //_artistService = artistService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var album = _albumService.GetAllAlbums();
            var artists = _albumService.GetAllArtists();
            var songs = _albumService.GetAllSongs();
            return View(album);
        }
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumService.GetAlbumAndRelatedById(id.Value);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        [Authorize(Roles="admin")]
        public IActionResult Create()
        {
            var album = _albumService.GetAllAlbums();
            var artists = _albumService.GetAllArtists();
            var songs = _albumService.GetAllSongs();
            ViewData["IdArtist"] = new SelectList(artists, "Id", "Name");
            //ViewData["Songs"] = new MultiSelectList(songs, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Title,Duration,ImageFile,ReleaseDate,IdArtist")] Album album)
        {
            var albums = _albumService.GetAllAlbums();
            album.ReleaseDate = album.ReleaseDate.ToUniversalTime();
            await _albumService.AddAlbumAsync(album);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumService.GetAlbumById(id.Value);

            if (_albumService == null)
            {
                return NotFound();
            }
            // var genres = _genreService.GetAllGenres();
           // var album = _albumService.GetAllAlbums();
            var artists = _albumService.GetAllArtists();
            var songs = _albumService.GetAllSongs();
            ViewData["IdArtist"] = new SelectList(artists, "Id", "Name");
            return View(album);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditAsync(int id, [Bind("Id,Title,Duration,ImageFile,ReleaseDate,IdArtist")] Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            // var genres = _genreService.GetAllGenres();
            album.ReleaseDate = album.ReleaseDate.ToUniversalTime();
            //if (ModelState.IsValid)
            //{
            try
            {
                await _albumService.UpdateAlbumAsync(album);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_albumService.AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            // return View(genre);

        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumService.GetAlbumAndRelatedById(id.Value);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var album = _albumService.GetAlbumById(id);
            if (album != null)
            {
                _albumService.DeleteAlbum(id);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AlbumGroupByArtist(int artistId)
        {
            var album = _albumService.GetAllAlbumsByArtist(artistId);

           
            return View(album);
        }

      

    }
}
