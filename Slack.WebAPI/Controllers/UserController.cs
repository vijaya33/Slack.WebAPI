using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slack.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Slack.WebAPI.Data;

namespace Slack.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly SlackDbContext _context;
        public UserController(SlackDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.Select(u => new { u.Id, u.DisplayName, u.Email }).ToList();
            return Ok(users);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

