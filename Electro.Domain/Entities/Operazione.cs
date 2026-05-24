namespace Electro.Domain.Entities
{
    public class Operazione
    {
        public int Id { get; set; }
        public string Descrizione { get; set; } = string.Empty;
        public DateTime? DataIntervento { get; set; }
        public DateTime? DataCompletamento { get; set; }
        public decimal? CostoManodopera { get; set; }
        public string? Note { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public ICollection<MaterialeUtilizzato> MaterialiUtilizzati { get; set; } = [];
    }
}
