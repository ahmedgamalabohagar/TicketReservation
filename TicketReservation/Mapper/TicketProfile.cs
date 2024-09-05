using AutoMapper;
using DAL.Entities;
using TicketReservation.Models;

namespace TicketReservation.Mapper
{
    public class TicketProfile : Profile
    {
        protected TicketProfile()
        {
            CreateMap<TicketVM, Ticket>();
        }
    }
}
