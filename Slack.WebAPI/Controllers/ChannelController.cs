using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slack.WebAPI.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Slack.WebAPI.Data;
using Slack.WebAPI.Models;

namespace Slack.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ChannelController : ControllerBase
    {
        private readonly SlackDbContext _context;
        public ChannelController(SlackDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetChannels()
        {
            var channels = _context.Channels.Select(c => new { c.Id, c.Name, c.IsPrivate }).ToList();
            return Ok(channels);
        }

        [HttpPost]
        public IActionResult CreateChannel([FromBody] Channel channel)
        {
            channel.Id = Guid.NewGuid();
            _context.Channels.Add(channel);
            _context.SaveChanges();
            return Ok(channel);
        }
    }
}

