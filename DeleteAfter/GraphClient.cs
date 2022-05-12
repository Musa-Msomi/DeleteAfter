using AutoMapper;
using DeleteAfter.Models;
using Microsoft.Graph;
using System.Net.Http.Headers;

namespace DeleteAfter
{
    public class GraphClient : IGraphClient
    {
        private readonly IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;


        public GraphClient(IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            string token = _contextAccessor.HttpContext.Request.Headers["Authorization"];
            string accesstoken = token.Replace("Bearer",string.Empty).Trim();

            GraphServiceClient graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(provider =>
  {
      provider.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

      return Task.FromResult(0);

  }));

            var startOfWeek = DateTime.Now;
            var endOfWeek = startOfWeek.AddDays(7);

            var viewOptions = new List<QueryOption>
            {
                new QueryOption("startDateTime", startOfWeek.ToString("o")),
                new QueryOption("endDateTime", endOfWeek.ToString("o"))
            };


            var myEvents = await graphClient.Me.CalendarView
                .Request(viewOptions)
                .Header("Prefer", "outlook.timezone=\"South Africa Standard Time\"")
                .Select(e => new
                {
                    e.Subject,
                    // e.Body,
                    e.BodyPreview,
                    e.Start,
                    e.End,
                    e.Organizer,
                    e.Location
                })
                .OrderBy("start/DateTime")
                .GetAsync();

            var testing = myEvents.AsEnumerable();

            // var eventsToReturn = _mapper.Map<IEnumerable<EventsDTO>>(testing);

            //  return eventsToReturn;
            return testing;

        }

        public async Task<IEnumerable<EventsDTO>> GetAllEventsViaDTO(DateTime? start, DateTime? end)
        {
            string token = _contextAccessor.HttpContext.Request.Headers["Authorization"];
            string accesstoken = token.Replace("Bearer", string.Empty).Trim();


            GraphServiceClient graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(provider =>
            {
                provider.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

                return Task.FromResult(0);

            }));
            var startOfWeek = start ?? DateTime.Now;
            var endOfWeek = end ?? startOfWeek.AddDays(2);



            
            

            var viewOptions = new List<QueryOption>
            {
                new QueryOption("startDateTime", startOfWeek.ToString("o")),
                new QueryOption("endDateTime", endOfWeek.ToString("o"))
            };

            var myEvents = await graphClient.Me.CalendarView
                .Request(viewOptions)
                .Header("Prefer", "outlook.timezone=\"South Africa Standard Time\"")
                .GetAsync();

            var testing = myEvents.AsEnumerable();

            var eventsToReturn = _mapper.Map<IEnumerable<EventsDTO>>(testing);

            return eventsToReturn;

        }

    }
}
