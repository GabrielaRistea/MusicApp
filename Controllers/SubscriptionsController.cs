using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Services;
using Music_App.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Music_App.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly UserManager<User> _userManager;
        public SubscriptionsController(ISubscriptionService subscriptionService, UserManager<User> userManager)
        {
            _subscriptionService = subscriptionService;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var subscription = _subscriptionService.GetAllSubscriptions();
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Include(u => u.Subscription).FirstOrDefaultAsync(u => u.Id == userId);

            ViewBag.UserSubscriptionId = user?.IdSub;
            return View(subscription);
        }
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = _subscriptionService.GetSubscriptionById(id.Value);

            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var subscription = _subscriptionService.GetAllSubscriptions();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create([Bind("Id,Type,Price,Duration,Description")] Subscription subscription)
        {
            var subscriptions = _subscriptionService.GetAllSubscriptions();

            _subscriptionService.AddSubscription(subscription);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = _subscriptionService.GetSubscriptionById(id.Value);

            if (_subscriptionService == null)
            {
                return NotFound();
            }
            // var genres = _genreService.GetAllGenres();

            return View(subscription);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id, [Bind("Id,Type,Price,Duration,Description")] Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return NotFound();
            }

            // var genres = _genreService.GetAllGenres();

            //if (ModelState.IsValid)
            //{
            try
            {
                _subscriptionService.UpdateSubscription(subscription);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_subscriptionService.SubscriptionExists(id))
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

            var subscription = _subscriptionService.GetSubscriptionById(id.Value);

            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var subscription = _subscriptionService.GetSubscriptionById(id);
            if (subscription != null)
            {
                _subscriptionService.DeleteSubscription(id);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> BuySubscription(int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var user = _userManager.Users.Include(u => u.Subscription).FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var subscription = _subscriptionService.GetSubscriptionById(id);
            if (subscription == null)
            {
                return NotFound();
            }

            user.IdSub = subscription.Id;
            user.Subscription = subscription;
            //_userManager.UpdateAsync(user); 
            var result = await _userManager.UpdateAsync(user);

            TempData["Message"] = "Subscription activated!";
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Unsubscribe()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users.Include(u => u.Subscription).FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return NotFound();

            user.IdSub = null;  
            user.Subscription = null;

            var result = await _userManager.UpdateAsync(user);

            TempData["Message"] = "You have unsubscribed.";
            return RedirectToAction("Index");
        }


    }
}
