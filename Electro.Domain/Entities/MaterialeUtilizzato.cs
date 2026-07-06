namespace Electro.Domain.Entities
{
    // Join Operazione N — N Materiale, con quantità e prezzo storico.
    public class MaterialeUtilizzato
    {
        public int Id { get; set; }

        // FK verso Operazione
        public int OperazioneId { get; set; }
        public Operazione Operazione { get; set; } = null!;

        // FK verso Materiale
        public int MaterialeId { get; set; }
        public Materiale Materiale { get; set; } = null!;

        public decimal Quantita { get; set; }
        public decimal PrezzoUnitarioStorico { get; set; }
    }
}
