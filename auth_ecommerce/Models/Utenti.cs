using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        //  Relazione 1,M  utenti -> ruoli
        //foreign key
        public int RuoloId { get; set; }
        
        //  proprietà di navigazione verso ruoli
        [ForeignKey("RuoloId")]
        public Ruoli Ruolo { get; set; }
    }
}

