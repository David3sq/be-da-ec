using System.ComponentModel.DataAnnotations;

namespace auth_ecommerce.Models;

public class Ruoli
{
    [Key]
    public int Id { get; set; }
    public List<string> Roles { get; set; } = new List<string> {"Admin","Manager","User"};
}