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
            var gig = new Gig
            {
                ArtistId = User.Identity.Name,
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