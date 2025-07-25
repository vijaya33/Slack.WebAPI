using System.Threading.Channels;

using Slack.WebAPI.Models;


namespace Slack.WebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SlackDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
                return; // Already seeded

            // Seed users
            var users = new User[]
            {
                new User { DisplayName = "Alice Johnson", Email = "alice@example.com" },
                new User { DisplayName = "Bob Smith", Email = "bob@example.com" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            // Seed channels
            var channels = new Slack.WebAPI.Models.Channel[]
            {
                new Slack.WebAPI.Models.Channel { Name = "general", IsPrivate = false },
                new Slack.WebAPI.Models.Channel { Name = "random", IsPrivate = false }
            };
            context.Channels.AddRange(channels);
            context.SaveChanges();

            // Seed channel memberships
            var alice = context.Users.First(u => u.Email == "alice@example.com");
            var general = context.Channels.First(c => c.Name == "general");
            context.UserChannels.Add(new UserChannel { UserId = alice.Id, ChannelId = general.Id });
            context.SaveChanges();

            // Seed messages
            var messages = new Message[]
            {
                new Message { ChannelId = general.Id, UserId = alice.Id, Text = "Welcome to the general channel!", Timestamp = DateTime.UtcNow }
            };
            context.Messages.AddRange(messages);
            context.SaveChanges();
        }
    }
}

