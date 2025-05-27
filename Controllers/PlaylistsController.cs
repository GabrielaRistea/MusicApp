using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_App.Models;
using Music_App.Services;
using Music_App.Services.Interfaces;
using System.Security.Claims;

namespace Music_App.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly UserManager<User> _userManager;
        public PlaylistsController(IPlaylistService playlistService, UserManager<User> userManager)
        {
            _playlistService = playlistService;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.GetUserAsync(User);
            //var playlist = _playlistService.GetAllPlaylists();
            var user = await _userManager.GetUserAsync(User);
            var playlist = _playlistService.GetByUserId(user.Id);
            return View(playlist);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var playlist = _playlistService.GetPlaylistDetails(id);

            if (playlist == null)
                return NotFound();

            return View(playlist);
        }
        [Authorize]
        public IActionResult Create()
        {
            var playlist = _playlistService.GetAllPlaylists();
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Name,Duration")] Playlist playlist)
        {
            //var playlists = _playlistService.GetAllPlaylists();
            var user = await _userManager.GetUserAsync(User);
            playlist.IdUser = user.Id;

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userplaylist = _userManager.Users.Include(u => u.Subscription).FirstOrDefault(u => u.Id == userId);

            if (userplaylist?.Subscription == null || userplaylist.Subscription.Type != "Premium")
            {
                TempData["Error"] = "You have to upgrade to Premium to create playlists.";
                return RedirectToAction("Index");
            }

            _playlistService.AddPlaylist(playlist);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = _playlistService.GetPlaylistById(id.Value);

            if (_playlistService == null)
            {
                return NotFound();
            }

            return View(playlist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(int id, [Bind("Name,Duration")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            try
            {
                _playlistService.UpdatePlaylist(playlist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_playlistService.PlaylistExists(id))
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
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = _playlistService.GetPlaylistById(id.Value);

            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            var playlist = _playlistService.GetPlaylistById(id);
            if (playlist != null)
            {
                _playlistService.DeletePlaylist(id);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromPlaylist(int playlistId, int songId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var playlist = _playlistService.GetPlaylistById(playlistId);
            if (playlist == null || playlist.IdUser != userId)
                return Forbid();

            var result = await _playlistService.RemoveSongFromPlaylistAsync(playlistId, songId);
            TempData["Message"] = result;

            //return RedirectToAction("Index");
            return RedirectToAction("Details", "Playlists", new { id = playlistId });
        }

        [Authorize]
        public IActionResult DeleteUserPlaylist(int? id)
        {
            if (id == null)
                return NotFound();

            var playlist = _playlistService.GetPlaylistById(id.Value);

            if (playlist == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (playlist.IdUser != userId)
                return Forbid();

            return View(playlist);
        }
        [HttpPost, ActionName("DeleteUserPlaylist")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteUserPlaylistConfirmed(int id)
        {
            var playlist = _playlistService.GetPlaylistById(id);
            if (playlist == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (playlist.IdUser != userId)
                return Forbid();

            _playlistService.DeletePlaylist(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
