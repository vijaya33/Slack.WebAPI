//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Slack.WebAPI.Models
{
    public class Channel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public ICollection<UserChannel> UserChannels { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}

