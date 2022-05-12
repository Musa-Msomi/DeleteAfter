using DeleteAfter.Models;
using DeleteAfter.Service;
using MediatR;

namespace DeleteAfter.Queries
{
    public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUpcomingEventsQuery, IEnumerable<EventsDTO>>
    {
        private readonly IEventService _eventService;

        public GetUpcomingEventsQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public Task<IEnumerable<EventsDTO>> Handle(GetUpcomingEventsQuery request, CancellationToken cancellationToken)
        {
            var upcoming = _eventService.GetAllEvents();

            return upcoming; 
        }
    }
}
