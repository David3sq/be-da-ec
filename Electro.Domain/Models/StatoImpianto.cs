namespace Electro.Domain.Models
{
    /// <summary>
    /// Stato dell'impianto. È un campo cache derivato:
    /// - Bozza: appena creato, nessuna operazione completata
    /// - Attivo: triggerato automaticamente alla prima operazione completata
    /// - Dismesso: impostato manualmente (cliente perso, impianto rimosso)
    /// </summary>
    public enum StatoImpianto
    {
        Bozza = 0,
        Attivo = 1,
        Dismesso = 2
    }
}
