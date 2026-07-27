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
            CreateMap<Utente, UtentiDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

            // Mappa da UtentiDto a Utenti
            CreateMap<UtentiDto, Utente>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        }
    }
}