using System.ComponentModel.DataAnnotations;

namespace auth_ecommerce.Models
{
    public class Utenti
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    }
}

