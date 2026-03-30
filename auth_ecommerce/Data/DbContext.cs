
using Electro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthJWT.Data
{
    public class AuthContext : DbContext
    {
        public DbSet<Utenti> Utenti { get; set; } = default!;
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }
        
    }
}