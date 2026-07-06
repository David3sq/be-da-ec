namespace Electro.Domain.Entities
{
    public class DatiPagamentoUtente
    {
        public int Id { get; set; }

        // FK 1:0..1 verso Utente
        public int UtenteId { get; set; }
        public Utente Utente { get; set; } = null!;

        public string? RagioneSociale { get; set; }
        public string? IndirizzoFatturazione { get; set; }
        public string? CittaFatturazione { get; set; }
        public string? CapFatturazione { get; set; }
        public string? ProvinciaFatturazione { get; set; }
        public string? CodiceFiscaleFatturazione { get; set; }
        public string? PartitaIvaFatturazione { get; set; }
        public string? Pec { get; set; }
        public string? CodiceSdi { get; set; }
        public string? Iban { get; set; }
    }
}
