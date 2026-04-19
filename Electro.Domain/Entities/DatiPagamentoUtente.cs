namespace Electro.Domain.Entities
{
    public class DatiPagamentoUtente
    {
        public int Id { get; set; }
        public int UtenteId { get; set; }
        public string? IBAN { get; set; }
        public string? Banca { get; set; }

        public Utenti Utente { get; set; } = null!;
    }
}
