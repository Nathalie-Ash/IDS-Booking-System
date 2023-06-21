using AutoMapper;
using IDS.Core.Models;
using IDS.Core.Models.Auth;
using IDSBookingSystem.Resources;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IDSBookingSystem.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Company, CompanyResource>();
            CreateMap<IDS.Core.Models.CustomUser, UserResource>();
            CreateMap<Reservation, ReservationResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<Role, RoleResource>();

            // Resource to Domain
            CreateMap<CompanyResource, Company>();
            CreateMap<UserResource, IDS.Core.Models.CustomUser>();
            CreateMap<ReservationResource, Reservation>();
            CreateMap<RoomResource, Room>();
            CreateMap<RoleResource, Role>();

            CreateMap<UserSignUpResource, IDS.Core.Models.Auth.CustomUser>()
    .ForMember<string>(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}

