namespace Electro.Domain.Entities
{
    public class TicketOperatore
    {
        public int TicketId { get; set; }
        public int UtenteId { get; set; }

        public Ticket Ticket { get; set; } = null!;
        public Utenti Utente { get; set; } = null!;
    }
}


