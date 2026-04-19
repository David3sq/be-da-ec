using Electro.Domain.Entities.Lookups;

namespace Electro.Domain.Entities
{
    public class Impianto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TipologiaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? PlanimetriaUrl { get; set; }
        public string? LayoutJson { get; set; }

        public Cliente Cliente { get; set; } = null!;
        public TipologiaImpianto Tipologia { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = [];
    }

}