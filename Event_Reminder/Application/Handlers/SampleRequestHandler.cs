using Event_Reminder.Application.Requests;
using Event_Reminder.Application.Responses;
using Event_Reminder.Interfaces;
using Google.Apis.Calendar.v3.Data;
using MediatR;

namespace Event_Reminder.Application.Handlers
{
    public class SampleRequestHandler: IRequestHandler<SampleRequest,SampleResponse>
    {
        private readonly IGoogleCalendarService _googleCalendarService;
        private readonly IGMailService _gmailService;
        public SampleRequestHandler(IGoogleCalendarService googleCalendarService, IGMailService gmailService) 
        { 
            _googleCalendarService = googleCalendarService;
            _gmailService = gmailService;
        }

        public async Task<SampleResponse> Handle(SampleRequest request, CancellationToken cancellationToken)
        {
            IList<Event> calendarEvents = await _googleCalendarService.GetEventsAsync(7);
            foreach (Event calendarEvent in calendarEvents) 
            {
                if (true)//Implement logic to determine if reminders are sent
                {
                    _gmailService.SendEmail(to: string.Join(",", calendarEvent.Attendees.Select(a => a.Email)),
                        subject: $"Reminder: {calendarEvent.Summary}",
                        body: $"This is a reminder for {calendarEvent.Summary}");
                }
            }

            return new SampleResponse();
        }
    }
}
