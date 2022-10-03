using AutoMapper;
using ITrivia.Types.Dtos.User;
using ITrivia.Types.Models;

namespace Itrivia.WebApi.Helpers
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<UserRequestDto, SegTusuario>()
            .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(des => des.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(des => des.Nombre, opt => opt.MapFrom(src => src.Name))
            .ForMember(des => des.Apellido, opt => opt.MapFrom(src => src.LastName))
            .ReverseMap();

            CreateMap<UserUpdateRequestDto, SegTusuario>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(des => des.Nombre, opt => opt.MapFrom(src => src.Name))
            .ForMember(des => des.Apellido, opt => opt.MapFrom(src => src.LastName))
            .ReverseMap();
            
            CreateMap<UserDto, SegTusuario>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.AltaFecha, opt => opt.MapFrom(src => src.CreateDate))
            .ForMember(des => des.ModiFecha, opt => opt.MapFrom(src => src.ModifyDate))
            .ForMember(des => des.Usuario, opt => opt.MapFrom(src => src.User))
            .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(des => des.Nombre, opt => opt.MapFrom(src => src.Name))
            .ForMember(des => des.Apellido, opt => opt.MapFrom(src => src.LastName))
            .ForMember(des => des.IdPerfil, opt => opt.MapFrom(src => src.ProfileId))
            .ForMember(des => des.IdRol, opt => opt.MapFrom(src => src.RolId))
            .ForMember(des => des.IdImagen, opt => opt.MapFrom(src => src.ImageId))
            .ReverseMap();
        }
    }
}
