using Event_Reminder.Application.Requests;
using Event_Reminder.Application.Responses;
using Event_Reminder.Interfaces;
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
            //_googleCalendarService.GetEvents();
            //_gmailService.SendEmail(to: "alex.leslie.b@gmail.com", subject: "Test Email", body: "wow");
            return new SampleResponse();
        }
    }
}
