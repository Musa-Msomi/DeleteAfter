using DeleteAfter.Models;
using Microsoft.Graph;

namespace DeleteAfter
{
    public interface IGraphClient
    {
        Task <IEnumerable<Event>> GetAllEvents();
        Task<IEnumerable<EventsDTO>> GetAllEventsViaDTO(DateTime? start, DateTime? end);
    }
}
