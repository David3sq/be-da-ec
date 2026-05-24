using Electro.Domain.Enums;

namespace Electro.Domain.Entities
{
    public class Impianto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descrizione { get; set; }
        public string? IndirizzoInstallazione { get; set; }
        public DateTime DataInstallazione { get; set; }

        /// <summary>
        /// Stato cache derivato dalle operazioni. Default Bozza alla creazione,
        /// triggerato ad Attivo dal service quando viene completata la prima operazione.
        /// Dismesso si imposta manualmente.
        /// </summary>
        public StatoImpianto Stato { get; set; } = StatoImpianto.Bozza;

        public int TipoImpiantoId { get; set; }
        public TipoImpianto TipoImpianto { get; set; } = null!;

        public int ProprietarioId { get; set; }
        public Utenti Proprietario { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = [];
    }
}
