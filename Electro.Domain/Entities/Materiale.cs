namespace Electro.Domain.Entities
{
    public class Materiale
    {
        public int Id { get; set; }
        public string Codice { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string? Descrizione { get; set; }
        public decimal PrezzoUnitario { get; set; }
        public string UnitaMisura { get; set; } = "pz";
        public bool IsAttivo { get; set; } = true;

        // 1:N — utilizzi di questo materiale nelle operazioni
        public ICollection<MaterialeUtilizzato> MaterialiUtilizzati { get; set; } = [];
    }
}
