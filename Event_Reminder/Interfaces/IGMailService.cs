
namespace Event_Reminder.Interfaces
{
    public interface IGMailService
    {
        public void SendEmail(string to, string subject, string body);
    }
}
