using common.AuthJWT.Models;

namespace common.AuthJWT.Data
{
    public class EcomContext : DbContext
    {
        public DbSet<Utenti> Utenti { get; set; } = default!;
        public EcomContext(DbContextOptions<EcomContext> options) : base(options) { }
        
    }
}