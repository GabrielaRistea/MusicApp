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
    public class GenresController : Controller
    {
        //private readonly MusicAppContext _context;

        //public GenresController(MusicAppContext context)
        //{
        //    _context = context;
        //}

        //// GET: Genres
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Genres.ToListAsync());
        //}

        //// GET: Genres/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var genre = await _context.Genres
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (genre == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(genre);
        //}

        //// GET: Genres/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Genres/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Type")] Genre genre)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        _context.Add(genre);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    //}
        //    return View(genre);
        //}

        //// GET: Genres/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var genre = await _context.Genres.FindAsync(id);
        //    if (genre == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(genre);
        //}

        //// POST: Genres/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] Genre genre)
        //{
        //    if (id != genre.Id)
        //    {
        //        return NotFound();
        //    }

        //    //if (ModelState.IsValid)
        //    //{
        //        try
        //        {
        //            _context.Update(genre);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GenreExists(genre.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    //}
        //    return View(genre);
        //}

        //// GET: Genres/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var genre = await _context.Genres
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (genre == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(genre);
        //}

        //// POST: Genres/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var genre = await _context.Genres.FindAsync(id);
        //    if (genre != null)
        //    {
        //        _context.Genres.Remove(genre);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GenreExists(int id)
        //{
        //    return _context.Genres.Any(e => e.Id == id);
        //}

        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public IActionResult Index()
        {
            var genre = _genreService.GetAllGenres();
            return View(genre);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _genreService.GetGenreById(id.Value);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        public IActionResult Create()
        {
            var genre = _genreService.GetAllGenres();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Type")] Genre genre)
        {
            var genres = _genreService.GetAllGenres();

            _genreService.AddGenre(genre);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _genreService.GetGenreById(id.Value);

            if (_genreService == null)
            {
                return NotFound();
            }
           // var genres = _genreService.GetAllGenres();
            
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Type")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

           // var genres = _genreService.GetAllGenres();

            //if (ModelState.IsValid)
            //{
            try
            {
                _genreService.UpdateGenre(genre);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_genreService.GenreExists(id))
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

            var genre = _genreService.GetGenreById(id.Value);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre != null)
            {
                _genreService.DeleteGenre(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
