namespace Electro.Domain.Entities
{
    public class Materiale
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal PrezzoListino { get; set; }

        public ICollection<TicketMateriale> TicketMateriali { get; set; } = [];
    }
}
