using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //private readonly MusicAppContext _context;

        //public AlbumsController(MusicAppContext context)
        //{
        //    _context = context;
        //}

        //// GET: Albums
        //public async Task<IActionResult> Index()
        //{
        //    var musicAppContext = _context.Albums.Include(a => a.Artist);
        //    return View(await musicAppContext.ToListAsync());
        //}

        //// GET: Albums/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var album = await _context.Albums
        //        .Include(a => a.Artist)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (album == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(album);
        //}

        //// GET: Albums/Create
        //public IActionResult Create()
        //{
        //    ViewData["IdArtist"] = new SelectList(_context.Artists, "Id", "Id");
        //    return View();
        //}

        //// POST: Albums/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Duration,Image,ReleaseDate,IdArtist")] Album album)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(album);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdArtist"] = new SelectList(_context.Artists, "Id", "Id", album.IdArtist);
        //    return View(album);
        //}

        //// GET: Albums/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var album = await _context.Albums.FindAsync(id);
        //    if (album == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdArtist"] = new SelectList(_context.Artists, "Id", "Id", album.IdArtist);
        //    return View(album);
        //}

        //// POST: Albums/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Duration,Image,ReleaseDate,IdArtist")] Album album)
        //{
        //    if (id != album.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(album);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AlbumExists(album.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdArtist"] = new SelectList(_context.Artists, "Id", "Id", album.IdArtist);
        //    return View(album);
        //}

        //// GET: Albums/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var album = await _context.Albums
        //        .Include(a => a.Artist)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (album == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(album);
        //}

        //// POST: Albums/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var album = await _context.Albums.FindAsync(id);
        //    if (album != null)
        //    {
        //        _context.Albums.Remove(album);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AlbumExists(int id)
        //{
        //    return _context.Albums.Any(e => e.Id == id);
        //}

        private readonly IAlbumService _albumService;
       // private readonly IArtistService _artistService;
        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
            //_artistService = artistService;
        }
        public IActionResult Index()
        {
            var album = _albumService.GetAllAlbums();
            var artists = _albumService.GetAllArtists();
            var songs = _albumService.GetAllSongs();
            return View(album);
        }
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
        public async Task<IActionResult> Create([Bind("Id,Title,Duration,ImageFile,ReleaseDate,IdArtist")] Album album)
        {
            var albums = _albumService.GetAllAlbums();
            album.ReleaseDate = album.ReleaseDate.ToUniversalTime();
            await _albumService.AddAlbumAsync(album);
            return RedirectToAction(nameof(Index));
        }
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
        public IActionResult AlbumGroupByArtist(int artistId)
        {
            var album = _albumService.GetAllAlbumsByArtist(artistId);

           
            return View(album);
        }

      

    }
}
