

using Event_Reminder.Application.Responses;
using MediatR;

namespace Event_Reminder.Application.Requests
{
    public record SampleRequest: IRequest<SampleResponse>
    {
    }
}
