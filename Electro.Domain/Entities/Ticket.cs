using Electro.Domain.Models;

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

        // FK verso TicketAnagrafica (tipologia)
        public int TicketAnagraficaId { get; set; }
        public TicketAnagrafica TicketAnagrafica { get; set; } = null!;

        // FK verso Impianto
        public int ImpiantoId { get; set; }
        public Impianto Impianto { get; set; } = null!;

        // FK verso Utente creatore.
        // Nome "UtenteCreatoreId" perché esprime il ruolo (chi ha aperto il ticket):
        // la navigation si chiama UtenteCreatore ed è di tipo Utente.
        public int UtenteCreatoreId { get; set; }
        public Utente UtenteCreatore { get; set; } = null!;

        // 1:N — operazioni del ticket
        public ICollection<Operazione> Operazioni { get; set; } = [];

        // M:N — operatori assegnati (via TicketOperatore)
        public ICollection<TicketOperatore> Operatori { get; set; } = [];
    }
}
