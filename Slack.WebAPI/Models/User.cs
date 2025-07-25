using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Slack.WebAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<UserChannel> UserChannels { get; set; }
    }
}

