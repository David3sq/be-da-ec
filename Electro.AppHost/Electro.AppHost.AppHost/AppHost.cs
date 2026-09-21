var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Electro_AuthJWT>("auth");
builder.AddProject<Projects.Electro_Core>("core");

builder.Build().Run();
