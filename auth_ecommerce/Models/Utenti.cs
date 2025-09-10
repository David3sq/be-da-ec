using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.auth_ecommerce.Models
{
    public class Utenti
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public string Role { get; set; } = string.Empty;
    }
}

