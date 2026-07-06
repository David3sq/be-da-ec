using Electro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Electro.Infrastructure.Data
{
    public class ElectroContext : DbContext
    {
        public DbSet<Utente> Utenti { get; set; } = default!;
        public ElectroContext(DbContextOptions<ElectroContext> options) : base(options) { }
        
    }
}