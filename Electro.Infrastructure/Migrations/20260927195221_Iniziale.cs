using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Iniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materiali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrezzoUnitario = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitaMisura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAttivo = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiali", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketAnagrafiche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAttivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAnagrafiche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipiImpianto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAttivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipiImpianto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnagraficheUtenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitaIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCreazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaModifica = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnagraficheUtenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnagraficheUtenti_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatiPagamentoUtenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndirizzoFatturazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CittaFatturazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapFatturazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinciaFatturazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceFiscaleFatturazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitaIvaFatturazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodiceSdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatiPagamentoUtenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatiPagamentoUtenti_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Impianti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndirizzoInstallazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInstallazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stato = table.Column<int>(type: "int", nullable: false),
                    TipoImpiantoId = table.Column<int>(type: "int", nullable: false),
                    ProprietarioId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impianti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impianti_TipiImpianto_TipoImpiantoId",
                        column: x => x.TipoImpiantoId,
                        principalTable: "TipiImpianto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Impianti_Utenti_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCreazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataChiusura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stato = table.Column<int>(type: "int", nullable: false),
                    StatoPagamento = table.Column<int>(type: "int", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "int", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImportoTotale = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ImportoPagato = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TicketAnagraficaId = table.Column<int>(type: "int", nullable: false),
                    ImpiantoId = table.Column<int>(type: "int", nullable: false),
                    UtenteCreatoreId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Impianti_ImpiantoId",
                        column: x => x.ImpiantoId,
                        principalTable: "Impianti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketAnagrafiche_TicketAnagraficaId",
                        column: x => x.TicketAnagraficaId,
                        principalTable: "TicketAnagrafiche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Utenti_UtenteCreatoreId",
                        column: x => x.UtenteCreatoreId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIntervento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCompletamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CostoManodopera = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operazioni_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketOperatori",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    DataAssegnazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsResponsabilePrincipale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOperatori", x => new { x.TicketId, x.UtenteId });
                    table.ForeignKey(
                        name: "FK_TicketOperatori_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketOperatori_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialiUtilizzati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperazioneId = table.Column<int>(type: "int", nullable: false),
                    MaterialeId = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    PrezzoUnitarioStorico = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialiUtilizzati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialiUtilizzati_Materiali_MaterialeId",
                        column: x => x.MaterialeId,
                        principalTable: "Materiali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialiUtilizzati_Operazioni_OperazioneId",
                        column: x => x.OperazioneId,
                        principalTable: "Operazioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnagraficheUtenti_UtenteId",
                table: "AnagraficheUtenti",
                column: "UtenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatiPagamentoUtenti_UtenteId",
                table: "DatiPagamentoUtenti",
                column: "UtenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Impianti_ProprietarioId",
                table: "Impianti",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Impianti_TipoImpiantoId",
                table: "Impianti",
                column: "TipoImpiantoId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialiUtilizzati_MaterialeId",
                table: "MaterialiUtilizzati",
                column: "MaterialeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialiUtilizzati_OperazioneId",
                table: "MaterialiUtilizzati",
                column: "OperazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_Operazioni_TicketId",
                table: "Operazioni",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOperatori_UtenteId",
                table: "TicketOperatori",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ImpiantoId",
                table: "Tickets",
                column: "ImpiantoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketAnagraficaId",
                table: "Tickets",
                column: "TicketAnagraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UtenteCreatoreId",
                table: "Tickets",
                column: "UtenteCreatoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnagraficheUtenti");

            migrationBuilder.DropTable(
                name: "DatiPagamentoUtenti");

            migrationBuilder.DropTable(
                name: "MaterialiUtilizzati");

            migrationBuilder.DropTable(
                name: "TicketOperatori");

            migrationBuilder.DropTable(
                name: "Materiali");

            migrationBuilder.DropTable(
                name: "Operazioni");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Impianti");

            migrationBuilder.DropTable(
                name: "TicketAnagrafiche");

            migrationBuilder.DropTable(
                name: "TipiImpianto");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
