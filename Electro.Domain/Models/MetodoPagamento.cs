namespace Electro.Domain.Models
{
    public enum MetodoPagamento
    {
        Contanti = 0,
        CartaCredito = 1,
        CartaDebito = 2,
        Bonifico = 3,
        PayPal = 4,
        Altro = 99
    }
}
