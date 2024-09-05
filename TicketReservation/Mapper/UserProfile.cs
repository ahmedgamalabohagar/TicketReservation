using AutoMapper;
using DAL.Entities;
using TicketReservation.Models;

namespace TicketReservation.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserVM, AppUser>();
        }
    }
}
