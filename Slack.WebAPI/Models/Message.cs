using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations;

namespace Slack.WebAPI.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ChannelId { get; set; }
        public Channel? Channel { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public string? Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

