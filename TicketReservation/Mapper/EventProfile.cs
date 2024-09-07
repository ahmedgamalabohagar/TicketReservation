using AutoMapper;
using DAL.Entities;
using TicketReservation.Models;

namespace TicketReservation.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventVM>().ReverseMap();
        }
    }
}
