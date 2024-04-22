using Microsoft.EntityFrameworkCore;

namespace Event_Reminder.Entities
{
    public class EventReminderDbContext: DbContext
    {
        public EventReminderDbContext(DbContextOptions<EventReminderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {

        }
    }
}
