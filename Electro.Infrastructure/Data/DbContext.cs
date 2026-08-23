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

            // ---- Precisione dei decimal, allineata alle colonne reali su ASI_Global ----
            // Senza HasPrecision EF assume decimal(18,2): i prezzi a 4 decimali e le
            // quantita' a 3 verrebbero arrotondati in silenzio in scrittura.
            modelBuilder.Entity<Materiale>()
                        .Property(m => m.PrezzoUnitario).HasPrecision(18, 4);

            modelBuilder.Entity<MaterialeUtilizzato>()
                        .Property(mu => mu.PrezzoUnitarioStorico).HasPrecision(18, 4);

            modelBuilder.Entity<MaterialeUtilizzato>()
                        .Property(mu => mu.Quantita).HasPrecision(18, 3);

            modelBuilder.Entity<Operazione>()
                        .Property(o => o.CostoManodopera).HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                        .Property(t => t.ImportoTotale).HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                        .Property(t => t.ImportoPagato).HasPrecision(18, 2);

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
