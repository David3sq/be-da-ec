namespace Electro.Domain.Entities
{
    public class Allegato
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string NomeFile { get; set; } = string.Empty;
        public string PercorsoFile { get; set; } = string.Empty;

        public Ticket Ticket { get; set; } = null!;
    }
}



