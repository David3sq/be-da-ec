namespace Electro.Domain.Entities
{
    public class TicketOperatore
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public int UtenteId { get; set; }
        public Utenti Utente { get; set; } = null!;

        public DateTime DataAssegnazione { get; set; } = DateTime.UtcNow;
        public bool IsResponsabilePrincipale { get; set; } = false;
    }
}
