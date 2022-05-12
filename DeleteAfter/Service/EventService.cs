using AutoMapper;
using DeleteAfter.Models;

namespace DeleteAfter.Service
{
    public class EventService : IEventService
    {
        private readonly GraphAPIClientService _service;
        private readonly IMapper _mapper;

        public EventService(GraphAPIClientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventsDTO>> GetAllEvents()
        {
            var eventsFromGraph = await _service.GetEventsFromGraph();

            var toReturn = _mapper.Map<IEnumerable<EventsDTO>>(eventsFromGraph);

            return toReturn;
        }
    }
}
