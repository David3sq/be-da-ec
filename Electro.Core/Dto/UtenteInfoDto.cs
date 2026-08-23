namespace Electro.Core.Dto
{
    // Proiezione di lettura: espone solo i campi pubblici dell'utente,
    // mai PasswordHash / PasswordSalt dell'entita' Utente.
    public class UtenteInfoDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }

        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
