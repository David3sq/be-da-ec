namespace Electro.Domain.Entities
{
    public class TicketMateriale
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int MaterialeId { get; set; }
        public decimal Quantita { get; set; }

        // Snapshot del prezzo al momento dell'utilizzo.
        // Rimane invariato anche se PrezzoListino cambia in futuro.
        public decimal PrezzoApplicato { get; set; }

        public Ticket Ticket { get; set; } = null!;
        public Materiale Materiale { get; set; } = null!;
    }
}


