using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GigHub.Mvc.Data;
using GigHub.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using GigHub.Mvc.Models;
using System;

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
        public IActionResult Create(GigFormViewModel model)
        {
            var artist = _context.Users.Single(u => u.Email == User.Identity.Name);

            var gig = new Gig
            {
                ArtistId = artist.Id,
                DateTime = DateTime.Parse(string.Format("{0} {1}", model.Date, model.Time)),
                GenreId = model.Genre,
                Venue = model.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}