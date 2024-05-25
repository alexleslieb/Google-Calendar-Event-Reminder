
namespace Event_Reminder.Entities
{
    public class Calendar_Event_Notification
    {
        public int Id { get; set; }
        public string Event_Id { get; set; } = string.Empty;
        public int Attendee_Id { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public bool NotificationSent { get; set; }

        public Calendar_Event Calendar_Event { get; set; }
        public Calendar_Event_Attendee Calendar_Event_Attendee { get; set; }
    }
}
