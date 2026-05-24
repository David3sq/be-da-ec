using Electro.Domain.Enums;
using Electro.Domain.Models;

namespace Electro.Domain.Entities
{
    public class Utenti
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
        public string Role { get; set; } = new Ruoli().User;
        public bool IsEnabled { get; set; } = false;

        public UtentiAnagrafica? Anagrafica { get; set; }
        public DatiPagamentoUtente? DatiPagamento { get; set; }
        public ICollection<Impianto> Impianti { get; set; } = [];
        public ICollection<Ticket> TicketsCreati { get; set; } = [];
        public ICollection<TicketOperatore> TicketOperatori { get; set; } = [];
    }
}
