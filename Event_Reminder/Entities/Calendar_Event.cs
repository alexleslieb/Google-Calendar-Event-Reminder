
namespace Event_Reminder.Entities
{
    public class Calendar_Event
    {
        public string Id { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        ICollection<Calendar_Event_Attendee> Calendar_Event_Attendees { get; set; }
        ICollection<Calendar_Event_Notification> Calendar_Event_Notifications { get; set; }
    }
}
