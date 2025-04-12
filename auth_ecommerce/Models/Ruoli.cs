using System.ComponentModel.DataAnnotations;

namespace auth_ecommerce.Models;

public class Ruoli
{
    [Key]
    public int Id { get; set; }
    public List<string> Roles { get; set; } = new List<string> {"Admin","Manager","User"};
    
    //relazione 1,M
    public List<Utenti>  Utenti { get; set; } = new List<Utenti>();
}