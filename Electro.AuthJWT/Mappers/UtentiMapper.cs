using Electro.AuthJWT.Dto;
using AutoMapper;
using Electro.Domain.Entities;

namespace Electro.AuthJWT.Mappers
{
    public class UtentiProfile : Profile
    {
        public UtentiProfile()
        {
            // Mappa da Utenti a UtentiDto
            CreateMap<Utenti, UtentiDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.IsEnabled));

            // Mappa da UtentiDto a Utenti
            CreateMap<UtentiDto, Utenti>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        }
    }
}