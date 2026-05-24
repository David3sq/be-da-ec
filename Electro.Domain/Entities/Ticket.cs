using Electro.Domain.Enums;

namespace Electro.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Codice { get; set; } = string.Empty;
        public DateTime DataCreazione { get; set; } = DateTime.UtcNow;
        public DateTime? DataChiusura { get; set; }
        public string? Note { get; set; }

        public StatoTicket Stato { get; set; } = StatoTicket.Pending;

        public StatoPagamento StatoPagamento { get; set; } = StatoPagamento.NonPagato;
        public MetodoPagamento? MetodoPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal? ImportoTotale { get; set; }
        public decimal? ImportoPagato { get; set; }

        public int TicketAnagraficaId { get; set; }
        public TicketAnagrafica TicketAnagrafica { get; set; } = null!;

        public int ImpiantoId { get; set; }
        public Impianto Impianto { get; set; } = null!;

        public int UtenteCreatoreId { get; set; }
        public Utenti UtenteCreatore { get; set; } = null!;

        public ICollection<Operazione> Operazioni { get; set; } = [];
        public ICollection<TicketOperatore> Operatori { get; set; } = [];
    }
}
