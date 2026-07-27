using Electro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Electro.Infrastructure.Data
{
    public class ElectroContext : DbContext
    {
        public ElectroContext(DbContextOptions<ElectroContext> options) : base(options) { }

        public DbSet<Utente> Utenti { get; set; } = default!;
        public DbSet<AnagraficaUtente> AnagraficheUtenti { get; set; } = default!;
        public DbSet<DatiPagamentoUtente> DatiPagamentoUtenti { get; set; } = default!;
        public DbSet<TipoImpianto> TipiImpianto { get; set; } = default!;
        public DbSet<Impianto> Impianti { get; set; } = default!;
        public DbSet<TicketAnagrafica> TicketAnagrafiche { get; set; } = default!;
        public DbSet<Materiale> Materiali { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;
        public DbSet<Operazione> Operazioni { get; set; } = default!;
        public DbSet<MaterialeUtilizzato> MaterialiUtilizzati { get; set; } = default!;
        public DbSet<TicketOperatore> TicketOperatori { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---- Chiave composta per la tabella di join (obbligatoria) ----
            modelBuilder.Entity<TicketOperatore>()
                        .HasKey(to => new { to.TicketId, to.UtenteId });

            // Ticket -> Utente (Creatore)
            modelBuilder.Entity<Ticket>()
                        .HasOne(t => t.UtenteCreatore)
                        .WithMany(u => u.TicketCreati)
                        .HasForeignKey(t => t.UtenteCreatoreId)
                        .OnDelete(DeleteBehavior.Restrict);

            // Ticket -> Impianto
            modelBuilder.Entity<Ticket>()
                        .HasOne(t => t.Impianto)
                        .WithMany(i => i.Ticket)
                        .HasForeignKey(t => t.ImpiantoId)
                        .OnDelete(DeleteBehavior.Restrict);

            // TicketOperatore -> Utente
            modelBuilder.Entity<TicketOperatore>()
                        .HasOne(to => to.Utente)
                        .WithMany(u => u.TicketAssegnati)
                        .HasForeignKey(to => to.UtenteId)
                        .OnDelete(DeleteBehavior.Restrict);

            // Impianto -> Utente (Proprietario)
            modelBuilder.Entity<Impianto>()
                        .HasOne(i => i.Proprietario)
                        .WithMany(u => u.Impianti)
                        .HasForeignKey(i => i.ProprietarioId)
                        .OnDelete(DeleteBehavior.Restrict);

            // Impianto -> TipoImpianto
            modelBuilder.Entity<Impianto>()
                        .HasOne(i => i.TipoImpianto)
                        .WithMany(t => t.Impianti)
                        .HasForeignKey(i => i.TipoImpiantoId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
