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
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [Authorize(Roles ="admin, user")]
        public IActionResult Index()
        {
            var genre = _genreService.GetAllGenres();
            return View(genre);
        }
        [Authorize]
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
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var genre = _genreService.GetAllGenres();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create([Bind("Id,Type")] Genre genre)
        {
            var genres = _genreService.GetAllGenres();

            _genreService.AddGenre(genre);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id, [Bind("Id,Type")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
