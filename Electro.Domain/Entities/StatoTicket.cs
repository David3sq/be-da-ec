namespace Electro.Domain.Entities.Lookups
{
    public class StatoTicket
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<Ticket> Tickets { get; set; } = [];
    }
}
