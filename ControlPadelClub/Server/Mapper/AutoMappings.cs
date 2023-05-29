using AutoMapper;
using ControlPadelClub.Shared.DTOs;
using ControlPadelClub.Shared.Entities;

namespace ControlPadelClub.Server.Mapper
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<UsuarioRegistrado, UsuarioRegistradoDTO>().ReverseMap();
            CreateMap<JugadorInvitado, JugadorInvitadoDTO>().ReverseMap();
 
            CreateMap<LoginDTO, UsuarioRegistradoDTO>()
                .ForMember(dest => dest.Nick, act => act.MapFrom(src => src.Username))
                .ForMember(dest => dest.JugadorId, act => act.MapFrom(src => src.Id)).ReverseMap()
                .ReverseMap();

            CreateMap<Pista, PistaDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<PerfilOptions, PerfilOptionsDTO>().ReverseMap();

            CreateMap<Pago, PagoDTO>().ReverseMap();

            CreateMap<Partida, PartidaDTO>().ReverseMap();

            CreateMap<Reserva, ReservaDTO>().ReverseMap();


        }

    }
}
