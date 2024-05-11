using Event_Reminder.Application.Requests;
using Event_Reminder.Application.Responses;
using Event_Reminder.Interfaces;
using MediatR;

namespace Event_Reminder.Application.Handlers
{
    public class SampleRequestHandler: IRequestHandler<SampleRequest,SampleResponse>
    {
        private readonly IGoogleCalendarService _googleCalendarService;
        public SampleRequestHandler(IGoogleCalendarService googleCalendarService) 
        { 
            _googleCalendarService = googleCalendarService;
        }

        public async Task<SampleResponse> Handle(SampleRequest request, CancellationToken cancellationToken)
        {
            _googleCalendarService.GetEvents();
            return new SampleResponse();
        }
    }
}
