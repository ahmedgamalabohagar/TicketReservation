using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TicketReservation.Models;

namespace TicketReservation.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleVM, IdentityRole>();
        }
    }
}
