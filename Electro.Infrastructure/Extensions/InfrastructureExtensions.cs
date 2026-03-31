using Electro.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Electro.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        // Metodo che aggiunge il contesto del database al container di iniezione delle dipendenze
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElectroContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        // Configura l'autenticazione JWT
        public static IServiceCollection JwtConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            var tokenKey = configuration.GetSection("AppSettings:Token").Value;

            if (string.IsNullOrEmpty(tokenKey))
                throw new InvalidOperationException("La chiave del token JWT non è configurata. Verifica il file appsettings.json.");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                var token = context.Request.Headers["Authorization"]
                                    .FirstOrDefault()?.Split(" ").Last();

                                if (!string.IsNullOrEmpty(token))
                                    context.Token = token;

                                return Task.CompletedTask;
                            }
                        };

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

            return services;
        }

        // Metodo che aggiunge una policy di autorizzazione tramite delle dipendenze
        public static IServiceCollection AddPolicy(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Owner", policy =>
                    policy.RequireRole("Owner"));

                options.AddPolicy("Admin", policy =>
                    policy.RequireRole("Owner", "Admin"));

                options.AddPolicy("Technician", policy =>
                    policy.RequireRole("Owner", "Admin", "Technician"));

                options.AddPolicy("User", policy =>
                    policy.RequireRole("Owner", "Admin", "Technician", "User"));

                options.AddPolicy("UserEnabled", policy =>
                    policy.RequireClaim("IsEnabled", "True"));
            });

            return services;
        }
    }
}
