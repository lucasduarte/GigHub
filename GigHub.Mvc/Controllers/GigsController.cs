using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GigHub.Mvc.Data;
using GigHub.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using GigHub.Mvc.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace GigHub.Mvc.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Attending()
        {
            var userId = _context.Users.Single(u => u.Email == User.Identity.Name).Id;
            var viewModelgigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = viewModelgigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending"
            };


            return View("Gigs", viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GigFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _context.Genres.ToList();
                return View("Create", model);
            }
                

            var artist = _context.Users.Single(u => u.Email == User.Identity.Name);

            var gig = new Gig
            {
                ArtistId = artist.Id,
                DateTime = model.GetDateTime(),
                GenreId = model.Genre,
                Venue = model.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}