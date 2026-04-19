namespace Electro.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? RagioneSociale { get; set; }
        public string? CodiceFiscale { get; set; }
        public string? PartitaIVA { get; set; }
        public string? Email { get; set; }
        public string? Indirizzo { get; set; }

        public ICollection<Impianto> Impianti { get; set; } = [];
    }
}

