namespace Electro.Domain.Entities
{
    public class TicketAnagrafica
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descrizione { get; set; }
        public bool IsAttivo { get; set; } = true;

        public ICollection<Ticket> Ticket { get; set; } = [];
    }
}
