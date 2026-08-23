using Electro.Core.Dto;
using Electro.Domain.Shared;
using Electro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Electro.Core.Services
{
    public class InfoUserServices
    {
        private readonly ElectroContext _context;

        public InfoUserServices(ElectroContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<UtenteInfoDto?>> GetInfo(int utenteId)
        {
            var response = new ServiceResponse<UtenteInfoDto?>
            {
                Data = null,
                Success = false,
                Message = "Utente non trovato"
            };

            var utente = await _context.Utenti
                .AsNoTracking()
                .Include(u => u.AnagraficaUtente)
                .FirstOrDefaultAsync(u => u.Id == utenteId);

            if (utente is null)
                return response;

            response.Data = new UtenteInfoDto
            {
                Id = utente.Id,
                Username = utente.Username,
                Role = utente.Role,
                IsEnabled = utente.IsEnabled,
                Nome = utente.AnagraficaUtente?.Nome,
                Cognome = utente.AnagraficaUtente?.Cognome,
                Email = utente.AnagraficaUtente?.Email,
                Telefono = utente.AnagraficaUtente?.Telefono
            };
            response.Success = true;
            response.Message = "Utente trovato";

            return response;
        }

        public async Task<ServiceResponse<List<UtenteInfoDto?>>> GetInfoDisabledUser()
        {
            var response = new ServiceResponse<List<UtenteInfoDto?>>
            {
                Data = new List<UtenteInfoDto?>(),
                Success = false,
                Message = "Non ci sono utenti disabilitati"
            };

            var utentiDisabilitati = await _context.Utenti
                .AsNoTracking()
                .Include(u => u.AnagraficaUtente)
                .Where(u => !u.IsEnabled)
                .ToListAsync();

            if (utentiDisabilitati is null || !utentiDisabilitati.Any())
                return response;

            foreach (var utente in utentiDisabilitati)
            {
                response.Data.Add(new UtenteInfoDto
                {
                    Id = utente.Id,
                    Username = utente.Username,
                    Role = utente.Role,
                    IsEnabled = utente.IsEnabled,
                    Nome = utente.AnagraficaUtente?.Nome,
                    Cognome = utente.AnagraficaUtente?.Cognome,
                    Email = utente.AnagraficaUtente?.Email,
                    Telefono = utente.AnagraficaUtente?.Telefono
                });
            }


            response.Success = true;
            response.Message = "Utenti trovati";

            return response;
        }
    }
}
