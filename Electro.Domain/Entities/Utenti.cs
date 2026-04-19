using Electro.Domain.Enums;

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

        public DatiPagamentoUtente? DatiPagamento { get; set; }
        public ICollection<Ticket> TicketsCreati { get; set; } = [];
        public ICollection<TicketOperatore> TicketOperatori { get; set; } = [];
    }
}
