namespace ecommerce.auth_ecommerce.Models
{
    public class ServiceResponse<T>
    {
        //In Data va qualsiasi tipo di dato utile come Log
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
    }
}