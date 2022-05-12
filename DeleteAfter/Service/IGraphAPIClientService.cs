using Microsoft.Graph;

namespace DeleteAfter.Service
{
    public interface IGraphAPIClientService
    {
        Task<IEnumerable<Event>> GetEventsFromGraph();
    }
}
