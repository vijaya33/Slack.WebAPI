using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Slack.WebAPI.Data;
using Slack.WebAPI.Models;

namespace Slack.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly SlackDbContext _context;
        public MessageController(SlackDbContext context) => _context = context;

        [HttpGet("{channelId}")]
        public IActionResult GetMessages(Guid channelId)
        {
            var messages = _context.Messages
                .Where(m => m.ChannelId == channelId)
                .OrderBy(m => m.Timestamp)
                .Select(m => new
                {
                    m.Id,
                    m.UserId,
                    User = m.User.DisplayName,
                    m.Text,
                    m.Timestamp
                })
                .ToList();
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] Message message)
        {
            message.Id = Guid.NewGuid();
            message.Timestamp = DateTime.UtcNow;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok(message);
        }

        //public IActionResult Index()
        //{
        //   // return View();
        //}
    }
}
