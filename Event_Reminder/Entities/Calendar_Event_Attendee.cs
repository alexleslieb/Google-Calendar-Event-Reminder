

namespace Event_Reminder.Entities
{
    public class Calendar_Event_Attendee
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string ResponseStatus { get; set; } = string.Empty;
        public string Comment {  get; set; } = string.Empty;
        public bool? Optional { get; set; }

        public Calendar_Event Calendar_Event { get; set; }
        public ICollection<Calendar_Event_Notification> Calendar_Event_Notifications { get; set; }
    }
}
