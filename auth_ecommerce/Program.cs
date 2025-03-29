// GlobalUsings.cs (opzionale, se preferisci metterli in un file separato)
// Puoi anche inserirli direttamente in Program.cs se preferisci.
global using ecommerce.auth_ecommerce.Dto;
global using ecommerce.auth_ecommerce.Models;
global using ecommerce.auth_ecommerce.Data;
global using ecommerce.auth_ecommerce.Mappers;
global using Microsoft.Extensions.Logging;
global using ecommerce.auth_ecommerce.Services;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using System.Collections.Generic;
global using System.Threading.Tasks;
global using System;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using AutoMapper;
global using Microsoft.OpenApi.Models;
global using System.Text.Json.Serialization;
global using System.Linq;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Configurazione dei servizi nel container.

// Registrazione del contesto DB con SQL Server (assicurati di avere la stringa di connessione "DefaultConnection" in appsettings.json)
builder.Services.AddDbContext<EcomContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Aggiunta dei controller.
builder.Services.AddControllers();

// Registrazione dei servizi personalizzati
builder.Services.AddScoped<AuthService>();

// Configurazione di AutoMapper (se usato)
builder.Services.AddAutoMapper(typeof(Program));

// Aggiunta degli endpoint per API Explorer (Swagger).
builder.Services.AddEndpointsApiExplorer();

// Configurazione di Swagger.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce API", Version = "v1" });

    // Definizione della sicurezza JWT per Swagger.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Inserisci il token JWT nel formato: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configura l'autenticazione JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Evento per la gestione del token nella richiesta
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                // Estrae il token dall'intestazione Authorization, rimuovendo "Bearer "
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
                return Task.CompletedTask;
            }
        };

        // Parametri di validazione del token JWT
        var tokenKey = builder.Configuration.GetSection("AppSettings:Token").Value;
        if (string.IsNullOrEmpty(tokenKey))
        {
            throw new InvalidOperationException("La chiave del token JWT non è configurata. Verifica il file appsettings.json.");
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, // Valida la chiave di firma del token
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)), // Chiave di firma
            ValidateIssuer = false, // Non valida l'issuer del token
            ValidateAudience = false // Non valida l'audience del token
        };
    });

var app = builder.Build();

// Configurazione della pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Abilita i middleware di autenticazione e autorizzazione.
app.UseAuthentication();
app.UseAuthorization();

// Mappa i controller per gestire le richieste.
app.MapControllers();

app.Run();