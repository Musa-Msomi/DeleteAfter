using AutoMapper;
using DeleteAfter.Models;
using DeleteAfter.Models.UpcomingEvents;
using Microsoft.Graph;


namespace DeleteAfter.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Event, EventsDTO>();
            CreateMap<Microsoft.Graph.Location, LocationDTO>();
            CreateMap<Microsoft.Graph.EmailAddress, EmailAddressDTO>();
            CreateMap<Microsoft.Graph.Recipient, OrganizerDTO>();
            CreateMap<Microsoft.Graph.DateTimeTimeZone, StartDTO>();
            CreateMap<Microsoft.Graph.DateTimeTimeZone, EndDTO>();
            CreateMap<ItemBody, BodyDTO>();
        }
    }
}
