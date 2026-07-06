using Electro.Domain.Models;

namespace Electro.Domain.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
        public string Role { get; set; } = new Ruolo().User;
        public bool IsEnabled { get; set; } = false;

        // 1:1
        public AnagraficaUtente? AnagraficaUtente { get; set; }
        // 1:0..1
        public DatiPagamentoUtente? DatiPagamentoUtente { get; set; }

        // 1:N — impianti di cui l'utente è proprietario
        public ICollection<Impianto> Impianti { get; set; } = [];

        // 1:N — ticket aperti dall'utente (FK Ticket.UtenteCreatoreId).
        // Nome navigation distinto perché esiste anche la relazione M:N come operatore.
        public ICollection<Ticket> TicketCreati { get; set; } = [];

        // M:N — ticket su cui l'utente è assegnato come operatore (via TicketOperatore)
        public ICollection<TicketOperatore> TicketAssegnati { get; set; } = [];
    }
}
