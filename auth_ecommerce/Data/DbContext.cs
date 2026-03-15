
using ASI_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace common.AuthJWT.Data
{
    public class AuthContext : DbContext
    {
        public DbSet<Utenti> Utenti { get; set; } = default!;
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }
        
    }
}