using DeleteAfter.Models;
using MediatR;

namespace DeleteAfter.Queries
{
    public class GetUpcomingEventsQuery : IRequest<IEnumerable<EventsDTO>>
    {
    }
}
