using DeleteAfter.Models;

namespace DeleteAfter.Service
{
    public interface IEventService
    {
        Task<IEnumerable<EventsDTO>> GetAllEvents();
    }
}
