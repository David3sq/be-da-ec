using common.AuthJWT.Data;
using common.AuthJWT.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Configurazione dei servizi nel container.

// Registrazione del contesto DB con SQL Server
builder.Services.AddDbContext<common.AuthJWT.Data.AuthContext>(options =>
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
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Asi API", Version = "v1" });

    // Definizione della sicurezza JWT per Swagger.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Formato token: Bearer {token}",
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
            ValidateIssuerSigningKey = true, 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
            ValidateIssuer = false, 
            ValidateAudience = false 
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