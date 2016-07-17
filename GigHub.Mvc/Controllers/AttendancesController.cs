using Microsoft.AspNetCore.Mvc;
using GigHub.Mvc.Data;
using GigHub.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using GigHub.Mvc.Dtos;

namespace GigHub.Mvc.Controllers
{
    [Produces("application/json")]
    [Route("api/Attendances")]
    [Authorize]
    public class AttendancesController : Controller
    {
        private ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Attend(AttendanceDto dto)
        {
            var userId = _context.Users.Single(u => u.Email == User.Identity.Name).Id;

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("The attendance already exists");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}