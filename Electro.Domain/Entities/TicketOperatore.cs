namespace Electro.Domain.Entities
{
    // Join Ticket N — N Utente: operatori assegnati a un ticket.
    public class TicketOperatore
    {
        // FK verso Ticket
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        // FK verso Utente
        public int UtenteId { get; set; }
        public Utente Utente { get; set; } = null!;

        public DateTime DataAssegnazione { get; set; } = DateTime.UtcNow;
        public bool IsResponsabilePrincipale { get; set; } = false;
    }
}
