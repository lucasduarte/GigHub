using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GigHub.Mvc.Data;
using GigHub.Mvc.ViewModels;

namespace GigHub.Mvc.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}