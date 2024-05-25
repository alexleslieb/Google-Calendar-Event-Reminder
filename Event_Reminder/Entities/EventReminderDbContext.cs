using Microsoft.EntityFrameworkCore;

namespace Event_Reminder.Entities
{
    public class EventReminderDbContext: DbContext
    {
        public DbSet<Calendar_Event> Calendar_Events {  get; set; }
        public DbSet<Calendar_Event_Attendee> Calendar_Event_Attendees { get; set; }
        public DbSet<Calendar_Event_Notification> Calendar_Event_Notifications { get; set; }

        public EventReminderDbContext(DbContextOptions<EventReminderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Calendar_Events
            modelBuilder.Entity<Calendar_Event>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Calendar_Event>()
                .Property(a => a.Start)
                .IsRequired(true);

            modelBuilder.Entity<Calendar_Event>()
                .Property(a => a.End)
                .IsRequired(true);
            #endregion

            #region Calendar_Event_Attendees
            modelBuilder.Entity<Calendar_Event_Attendee>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Calendar_Event_Attendee>()
                .Property(a => a.Email)
                .IsRequired(true);
            #endregion

            #region Calendar_Event_Notifications
            modelBuilder.Entity<Calendar_Event_Notification>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Calendar_Event_Notification>()
                .Property(a => a.Event_Id)
                .IsRequired(true);

            modelBuilder.Entity<Calendar_Event_Notification>()
                .Property(a => a.Attendee_Id)
                .IsRequired(true);

            modelBuilder.Entity<Calendar_Event_Notification>()
                .Property(a => a.NotificationDateTime)
                .IsRequired(true);

            modelBuilder.Entity<Calendar_Event_Notification>()
                .Property(a => a.NotificationSent)
                .IsRequired(true)
                .HasDefaultValue(false);
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {

        }
    }
}
