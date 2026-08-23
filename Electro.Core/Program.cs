using Electro.Core.Services;
using Electro.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

// Nome della policy CORS usata solo in sviluppo.
const string DevCorsPolicy = "ElectroDevCors";

var builder = WebApplication.CreateBuilder(args);

// Configurazione dei servizi nel container.

// Registrazione del contesto DB (ElectroContext) con SQL Server.
// La connection string arriva da ConnectionStrings:DefaultConnection.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

// Servizi applicativi di Electro.Core
builder.Services.AddScoped<InfoUserServices>();

// CORS: serve solo al client Flutter Web. Su desktop e su emulatore Android
// non c'e' un browser di mezzo, quindi non c'e' nessuna preflight da superare.
// In produzione elencare le origini note con .WithOrigins(...).
builder.Services.AddCors(options =>
{
    options.AddPolicy(DevCorsPolicy, policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Electro Core API", Version = "v1" });

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

// Validazione del token JWT emesso da Electro.AuthJWT.
// La chiave (AppSettings:Token) deve essere identica a quella di Electro.AuthJWT,
// altrimenti la firma non viene riconosciuta e ogni richiesta torna 401.
builder.Services.JwtConfiguration(builder.Configuration);

// Iniezione delle policy di autorizzazione definite in InfrastructureExtensions.
builder.Services.AddPolicy(builder.Configuration);

var app = builder.Build();

// Configurazione della pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Prima di UseAuthentication: la preflight OPTIONS arriva senza header
// Authorization e verrebbe respinta dall'autenticazione.
if (app.Environment.IsDevelopment())
{
    app.UseCors(DevCorsPolicy);
}

// Abilita i middleware di autenticazione e autorizzazione.
app.UseAuthentication();
app.UseAuthorization();

// Mappa i controller per gestire le richieste.
app.MapControllers();

app.Run();
