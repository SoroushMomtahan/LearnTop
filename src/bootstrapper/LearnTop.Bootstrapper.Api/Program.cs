using LearnTop.Bootstrapper.Api.Extensions;
using LearnTop.Bootstrapper.Api.Middlewares;
using LearnTop.Modules.Academy.Infrastructure;
using LearnTop.Modules.Blogs.Infrastructure;
using LearnTop.Modules.Identity.Infrastructure;
using LearnTop.Modules.Requests.Infrastructure;
using LearnTop.Modules.Users.Infrastructure;
using LearnTop.Shared.Application;
using LearnTop.Shared.Application.Services;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Infrastructure;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Tagging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });

    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Host.UseSerilog(static (context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Configuration.AddConfigurationFiles("academy", "Users");

builder.Services
    .AddApplicationConfiguration
        (LearnTop.Modules.Information.Application.AssemblyReference.AcademyAssembly,
        LearnTop.Modules.Users.Application.AssemblyReference.UsersAssembly,
        LearnTop.Modules.Blogs.Application.AssemblyReference.BlogsAssembly,
        LearnTop.Modules.Requests.Application.AssemblyReference.RequestsAssembly,
        Tagging.AssemblyReference.TaggingAssembly,
        LearnTop.Modules.Identity.Application.AssemblyReference.IdentityAssembly)
    
    .AddInfrastructureConfiguration(
        builder.Configuration.GetConnectionString("Cache")!);

builder.Services
    .AddInformationModule(builder.Configuration)
    .AddUsersModule(builder.Configuration)
    .AddBlogsModule(builder.Configuration)
    .AddRequestsModule(builder.Configuration)
    .AddTaggingModule(builder.Configuration)
    .AddIdentityModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseAuthorization();

app.MapEndpoints();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();
