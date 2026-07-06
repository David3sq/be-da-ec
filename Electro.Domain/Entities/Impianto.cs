using Electro.Domain.Models;

namespace Electro.Domain.Entities
{
    public class Impianto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descrizione { get; set; }
        public string? IndirizzoInstallazione { get; set; }
        public DateTime DataInstallazione { get; set; }

        // Stato cache (Bozza/Attivo/Dismesso)
        public StatoImpianto Stato { get; set; } = StatoImpianto.Bozza;

        // FK verso TipoImpianto (nome coerente con la classe)
        public int TipoImpiantoId { get; set; }
        public TipoImpianto TipoImpianto { get; set; } = null!;

        // FK verso Utente proprietario.
        // Qui il nome NON è "UtenteId" ma "ProprietarioId" perché esprime il ruolo:
        // la navigation si chiama Proprietario ed è di tipo Utente.
        public int ProprietarioId { get; set; }
        public Utente Proprietario { get; set; } = null!;

        // 1:N — ticket relativi a questo impianto
        public ICollection<Ticket> Ticket { get; set; } = [];
    }
}
