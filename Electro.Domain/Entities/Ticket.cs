using Electro.Domain.Entities.Lookups;
using Electro.Domain.Enums;

namespace Electro.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        // Colonna calcolata dal DB: 'T-' + CAST(Id AS NVARCHAR(10))
        // EF non scrive mai su questo campo — configurato come HasComputedColumnSql
        public string? CodiceTicket { get; set; }

        public TipoTicket Tipo { get; set; }

        // Nullable: valorizzato solo per TipoTicket.Intervento
        public int? ImpiantoId { get; set; }

        // Nullable: valorizzato solo per TipoTicket.NuovaInstallazione
        public int? TipologiaImpiantoRichiestaId { get; set; }

        public string Titolo { get; set; } = string.Empty;
        public DateTime DataApertura { get; set; } = DateTime.UtcNow;
        public int StatoId { get; set; }
        public int PrioritaId { get; set; }
        public int CreatoDaUtenteId { get; set; }

        public Impianto? Impianto { get; set; }
        public TipologiaImpianto? TipologiaRichiesta { get; set; }
        public StatoTicket Stato { get; set; } = null!;
        public Priorita Priorita { get; set; } = null!;
        public Utenti CreatoDa { get; set; } = null!;
        public ICollection<TicketOperatore> TicketOperatori { get; set; } = [];
        public ICollection<TicketMateriale> TicketMateriali { get; set; } = [];
        public ICollection<Allegato> Allegati { get; set; } = [];
    }
}


