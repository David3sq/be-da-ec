namespace Electro.Domain.Enums
{
    public enum TipoTicket
    {
        Intervento,         // Su impianto esistente → ImpiantoId valorizzato
        NuovaInstallazione  // Nessun impianto ancora → ImpiantoId null
    }
}
