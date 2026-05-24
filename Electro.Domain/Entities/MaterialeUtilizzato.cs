namespace Electro.Domain.Entities
{
    public class MaterialeUtilizzato
    {
        public int Id { get; set; }

        public int OperazioneId { get; set; }
        public Operazione Operazione { get; set; } = null!;

        public int MaterialeId { get; set; }
        public Materiale Materiale { get; set; } = null!;

        public decimal Quantita { get; set; }
        public decimal PrezzoUnitarioStorico { get; set; }
    }
}
