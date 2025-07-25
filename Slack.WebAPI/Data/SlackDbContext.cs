using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Channels;

using Microsoft.EntityFrameworkCore;
using Slack.WebAPI.Models;


namespace Slack.WebAPI.Data
{
    public class SlackDbContext : DbContext
    {
        public SlackDbContext(DbContextOptions<SlackDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Slack.WebAPI.Models.Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChannel> UserChannels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChannel>()
                .HasKey(uc => new { uc.UserId, uc.ChannelId });

            modelBuilder.Entity<UserChannel>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserChannels)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserChannel>()
                .HasOne(uc => uc.Channel)
                .WithMany(c => c.UserChannels)
                .HasForeignKey(uc => uc.ChannelId);
        }
    }
}

