namespace ecommerce.auth_ecommerce.Mappers
{
	public class UtentiProfile : Profile
	{
	    public UtentiProfile()
	    {
 	       // Mappa da Utenti a UtentiDto
 	       CreateMap<Utenti, UtentiDto>()
 	           .ForMember(dest => dest.Password, opt => opt.Ignore()) // Non mappiamo l'hash della password
 	           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

  	      // Mappa da UtentiDto a Utenti
  	      CreateMap<UtentiDto, Utenti>()
	           .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // La gestione dell'hash avviene altrove
	           .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
	           .ForMember(dest => dest.Role, opt => opt.Ignore()); // Non mappiamo l'hash della password
        //.ForMember(dest => dest.UtentiContatti, opt => opt.Ignore()); // Ignora navigazione
   		 }
	}
}