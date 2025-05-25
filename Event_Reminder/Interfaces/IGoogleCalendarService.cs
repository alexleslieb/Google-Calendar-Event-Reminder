using Google.Apis.Calendar.v3.Data;

namespace Event_Reminder.Interfaces
{
    public interface IGoogleCalendarService
    {
        public Task<IList<Event>> GetEventsAsync(int days);
    }
}
