namespace Electro.Domain.Entities.Lookups
{
    public class TipologiaImpianto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<Impianto> Impianti { get; set; } = [];
        public ICollection<Ticket> TicketsRichiesta { get; set; } = [];
    }
}


