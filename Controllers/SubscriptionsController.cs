using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_App.Context;
using Music_App.Models;
using Music_App.Services;
using Music_App.Services.Interfaces;

namespace Music_App.Controllers
{
    public class SubscriptionsController : Controller
    {
        //private readonly MusicAppContext _context;

        //public SubscriptionsController(MusicAppContext context)
        //{
        //    _context = context;
        //}

        //// GET: Subscriptions
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Subscriptions.ToListAsync());
        //}

        //// GET: Subscriptions/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subscription = await _context.Subscriptions
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (subscription == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(subscription);
        //}

        //// GET: Subscriptions/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Subscriptions/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Type,Price,Duration,Description")] Subscription subscription)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(subscription);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(subscription);
        //}

        //// GET: Subscriptions/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subscription = await _context.Subscriptions.FindAsync(id);
        //    if (subscription == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(subscription);
        //}

        //// POST: Subscriptions/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Price,Duration,Description")] Subscription subscription)
        //{
        //    if (id != subscription.Id)
        //    {
        //        return NotFound();
        //    }

        //    //if (ModelState.IsValid)
        //    //{
        //        try
        //        {
        //            _context.Update(subscription);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SubscriptionExists(subscription.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //   // }
        //    return View(subscription);
        //}

        //// GET: Subscriptions/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subscription = await _context.Subscriptions
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (subscription == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(subscription);
        //}

        //// POST: Subscriptions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var subscription = await _context.Subscriptions.FindAsync(id);
        //    if (subscription != null)
        //    {
        //        _context.Subscriptions.Remove(subscription);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SubscriptionExists(int id)
        //{
        //    return _context.Subscriptions.Any(e => e.Id == id);
        //}

        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        public IActionResult Index()
        {
            var subscription = _subscriptionService.GetAllSubscriptions();
            return View(subscription);
        }
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
        public IActionResult Create()
        {
            var subscription = _subscriptionService.GetAllSubscriptions();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Type,Price,Duration,Description")] Subscription subscription)
        {
            var subscriptions = _subscriptionService.GetAllSubscriptions();

            _subscriptionService.AddSubscription(subscription);
            return RedirectToAction(nameof(Index));
        }
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
        public IActionResult DeleteConfirmed(int id)
        {
            var subscription = _subscriptionService.GetSubscriptionById(id);
            if (subscription != null)
            {
                _subscriptionService.DeleteSubscription(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
