using AutoMapper;
using ITrivia.Types.Dtos.Autocomplete;
using ITrivia.Types.Dtos.Category;
using ITrivia.Types.Dtos.Challenge;
using ITrivia.Types.Dtos.GameType;
using ITrivia.Types.Dtos.HistoryPD;
using ITrivia.Types.Dtos.HistoryPS;
using ITrivia.Types.Dtos.Image;
using ITrivia.Types.Dtos.MultipleChoice;
using ITrivia.Types.Dtos.PairSelection;
using ITrivia.Types.Dtos.Profile;
using ITrivia.Types.Dtos.Rol;
using ITrivia.Types.Dtos.Section;
using ITrivia.Types.Dtos.Step;
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

            CreateMap<SegProle, RolDto>()
              .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
              .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
              .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
              .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
              .ForMember(des => des.Code, opt => opt.MapFrom(src => src.Codigo))
              .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
              .ReverseMap();

            CreateMap<GesTperfile, ProfileDto>()
             .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
             .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
             .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
             .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
             .ForMember(des => des.Experience, opt => opt.MapFrom(src => src.Exp))
             .ReverseMap();

            CreateMap<SegTusuario, UserDetailDto>()
                  .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
                  .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
                  .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
                  .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
                  .ForMember(des => des.LastName, opt => opt.MapFrom(src => src.Apellido))
                  .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
                  .ForMember(des => des.ProfileId, opt => opt.MapFrom(src => src.IdPerfil))
                  .ForMember(des => des.RolId, opt => opt.MapFrom(src => src.IdRol))
                  .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
                  .ForMember(des => des.Profile, opt => opt.MapFrom(src => src.IdPerfilNavigation))
                  .ForMember(des => des.Rol, opt => opt.MapFrom(src => src.IdRolNavigation))
                  .ForMember(des => des.Image, opt => opt.MapFrom(src => src.IdImagenNavigation))
                  .ReverseMap();

            CreateMap<GesTseccione, SectionDto>()
               .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
               .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
               .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
               .ForMember(des => des.CategoryId, opt => opt.MapFrom(src => src.IdCategoria))
               .ForMember(des => des.ChallengeCount, opt => opt.MapFrom(src => src.CantDesafios))
               .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Descripcion))
               .ForMember(des => des.Url_Image, opt => opt.MapFrom(src => src.UrlImagen))
               .ForMember(des => des.Activated, opt => opt.MapFrom(src => src.Activated))
               .ReverseMap();

            CreateMap<GesTseccione, SectionDetailDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.CategoryId, opt => opt.MapFrom(src => src.IdCategoria))
            .ForMember(des => des.ChallengeCount, opt => opt.MapFrom(src => src.CantDesafios))
            .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(des => des.Url_Image, opt => opt.MapFrom(src => src.UrlImagen))
            .ForMember(des => des.Category, opt => opt.MapFrom(src => src.IdCategoriaNavigation))
            .ForMember(des => des.Challenges, opt => opt.MapFrom(src => src.GesTdesafios))
            .ForMember(des => des.Activated, opt => opt.MapFrom(src => src.Activated))
            .ReverseMap();

            CreateMap<GesTcategoria, CategoryDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
                .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
                .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
                .ReverseMap();

            CreateMap<GesTdesafio, ChallengeDto>()
             .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
             .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
             .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
             .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
             .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
             .ForMember(des => des.SectionId, opt => opt.MapFrom(src => src.IdSeccion))
             .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Descripcion))
             .ForMember(des => des.Experience, opt => opt.MapFrom(src => src.Experiencia))
             .ForMember(des => des.StepsCount, opt => opt.MapFrom(src => src.CantEtapas))
             .ForMember(des => des.Activated, opt => opt.MapFrom(src => src.Activated))
             .ReverseMap();

            CreateMap<GesTdesafio, ChallengeDetailDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.SectionId, opt => opt.MapFrom(src => src.IdSeccion))
            .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(des => des.Experience, opt => opt.MapFrom(src => src.Experiencia))
            .ForMember(des => des.StepsCount, opt => opt.MapFrom(src => src.CantEtapas))
            .ForMember(des => des.Section, opt => opt.MapFrom(src => src.IdSeccionNavigation))
            .ForMember(des => des.Activated, opt => opt.MapFrom(src => src.Activated))
            .ReverseMap();

            CreateMap<GesThistPerfilDesafio, HistoryPDDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
                .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
                .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
                .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(des => des.ProfilelId, opt => opt.MapFrom(src => src.IdPerfil))
                .ForMember(des => des.ChallengeId, opt => opt.MapFrom(src => src.IdDesafio))
                .ReverseMap();

            CreateMap<GesThistPerfilSeccione, HistoryPSDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.ProfilelId, opt => opt.MapFrom(src => src.IdPerfil))
            .ForMember(des => des.SectionId, opt => opt.MapFrom(src => src.IdSeccion))
            .ReverseMap();

            CreateMap<GesTautocompletado, AutocompleteGameDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.Enunciate, opt => opt.MapFrom(src => src.Enunciado))
            .ReverseMap();

            CreateMap<GesTautocompletado, AutoCompleteDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.Enunciate, opt => opt.MapFrom(src => src.Enunciado))
            .ForMember(des => des.Answer, opt => opt.MapFrom(src => src.Respuesta))
            .ReverseMap();

            CreateMap<GesTmultiplechoice, MultipleChoiceDto>()
           .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
           .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
           .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
           .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
           .ForMember(des => des.Enunciate, opt => opt.MapFrom(src => src.Enunciado))
           .ForMember(des => des.CorrectOption, opt => opt.MapFrom(src => src.OpcionCorrecta))
           .ForMember(des => des.FirstOption, opt => opt.MapFrom(src => src.Opcion1))
           .ForMember(des => des.SecondOption, opt => opt.MapFrom(src => src.Opcion2))
           .ReverseMap();

            CreateMap<GesTselecPare, PairSelectionDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.FirstOption, opt => opt.MapFrom(src => src.Opcion1))
            .ForMember(des => des.FirstAnswer, opt => opt.MapFrom(src => src.Respuesta1))
            .ForMember(des => des.SecondOption, opt => opt.MapFrom(src => src.Opcion2))
            .ForMember(des => des.SecondAnswer, opt => opt.MapFrom(src => src.Respuesta2))
            .ForMember(des => des.ThirdOption, opt => opt.MapFrom(src => src.Opcion3))
            .ForMember(des => des.ThirdAnswer, opt => opt.MapFrom(src => src.Respuesta3))
            .ForMember(des => des.FourthOption, opt => opt.MapFrom(src => src.Opcion4))
            .ForMember(des => des.FourthAnswer, opt => opt.MapFrom(src => src.Respuesta4))
            .ReverseMap();

            CreateMap<GesPtipoJuego, GameTypeDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(des => des.Code, opt => opt.MapFrom(src => src.Codigo))
            .ReverseMap();

            CreateMap<GesTetapa, StepDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(des => des.ChallengeId, opt => opt.MapFrom(src => src.IdDesafio))
            .ForMember(des => des.GameTypeId, opt => opt.MapFrom(src => src.IdTipoJuego))
            .ReverseMap();

            CreateMap< GesTetapa, StepDetailDto >()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.User, opt => opt.MapFrom(src => src.Usuario))
            .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(des => des.ChallengeId, opt => opt.MapFrom(src => src.IdDesafio))
            .ForMember(des => des.Challenge, opt => opt.MapFrom(src => src.IdDesafioNavigation))
            .ForMember(des => des.MultipleChoiceId, opt => opt.MapFrom(src => src.IdMchoice))
            .ForMember(des => des.PairSelectionId, opt => opt.MapFrom(src => src.IdSpares))
            .ForMember(des => des.AutocompleteId, opt => opt.MapFrom(src => src.IdAutocompletado))
            .ForMember(des => des.AutoComplete, opt => opt.MapFrom(src => src.IdAutocompletadoNavigation))
            .ForMember(des => des.MultipleChoice, opt => opt.MapFrom(src => src.IdMchoiceNavigation))
            .ForMember(des => des.GameType, opt => opt.MapFrom(src => src.IdTipoJuegoNavigation))
            .ForMember(des => des.GameTypeId, opt => opt.MapFrom(src => src.IdTipoJuego))
            .ReverseMap();

            CreateMap<ParPimagene, ImageDto>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.IsDeleted, opt => opt.MapFrom(src => src.Baja))
            .ForMember(des => des.CreateDate, opt => opt.MapFrom(src => src.AltaFecha))
            .ForMember(des => des.ModifyDate, opt => opt.MapFrom(src => src.ModiFecha))
            .ForMember(des => des.Url_Image, opt => opt.MapFrom(src => src.UrlImagen))
            .ForMember(des => des.Code, opt => opt.MapFrom(src => src.Codigo))
            .ReverseMap();
        }
    }
}
