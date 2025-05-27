using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Services;
using Music_App.Services.Interfaces;

namespace Music_App.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;
        //private readonly IAlbumService _albumService;
        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
            //_albumService = albumService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var artist = _artistService.GetAllArtists();
            return View(artist);
        }
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetArtistById(id.Value);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var artist = _artistService.GetAllArtists();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageFile,Description")] Artist artist)
        {
            var artists = _artistService.GetAllArtists();

            await _artistService.AddArtistAsync(artist);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetArtistById(id.Value);

            if (_artistService == null)
            {
                return NotFound();
            }
            // var genres = _genreService.GetAllGenres();

            return View(artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditAsync(int id, [Bind("Id,Name,ImageFile,Description")] Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            // var genres = _genreService.GetAllGenres();

            //if (ModelState.IsValid)
            //{
            try
            {
                await _artistService.UpdateArtistAsync(artist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_artistService.ArtistExists(id))
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

            var artist = _artistService.GetArtistById(id.Value);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var artist = _artistService.GetArtistById(id);
            if (artist != null)
            {
                _artistService.DeleteArtist(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
