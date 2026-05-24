namespace Electro.Domain.Entities
{
    public class UtentiAnagrafica
    {
        public int Id { get; set; }

        public int UtenteId { get; set; }
        public Utenti Utente { get; set; } = null!;

        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Indirizzo { get; set; } = string.Empty;
        public string? Citta { get; set; }
        public string? Cap { get; set; }
        public string? Provincia { get; set; }
        public string? CodiceFiscale { get; set; }
        public string? PartitaIva { get; set; }

        public DateTime DataCreazione { get; set; } = DateTime.UtcNow;
        public DateTime? DataUltimaModifica { get; set; }
    }
}
