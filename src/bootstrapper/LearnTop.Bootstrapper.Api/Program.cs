using LearnTop.Bootstrapper.Api.Extensions;
using LearnTop.Bootstrapper.Api.Middlewares;
using LearnTop.Modules.Academy.Infrastructure;
using LearnTop.Modules.Users.Infrastructure;
using LearnTop.Shared.Application;
using LearnTop.Shared.Infrastructure;
using LearnTop.Shared.Presentation.Endpoints;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Host.UseSerilog(static (context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Configuration.AddConfigurationFiles("academy", "Users");

builder.Services
    .AddApplicationConfiguration
        (LearnTop.Modules.Academy.Application.AssemblyReference.AcademyAssembly,
        LearnTop.Modules.Users.Application.AssemblyReference.UsersAssembly)
    .AddInfrastructureConfiguration(
        [AcademyModule.ConfigureConsumers],
        builder.Configuration.GetConnectionString("Cache")!);

builder.Services
    .AddAcademyModule(builder.Configuration)
    .AddUsersModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
