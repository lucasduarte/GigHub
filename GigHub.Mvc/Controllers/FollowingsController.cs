using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GigHub.Mvc.Data;
using GigHub.Mvc.Models;
using GigHub.Mvc.Dtos;

namespace GigHub.Mvc.Controllers
{
    [Produces("application/json")]
    [Route("api/Followings")]
    [Authorize]
    public class FollowingsController : Controller
    {
        private ApplicationDbContext _context;

        public FollowingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Follow(FollowingDto dto)
        {
            var userId = _context.Users.Single(u => u.Email == User.Identity.Name).Id;

            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();

        }
    }
}