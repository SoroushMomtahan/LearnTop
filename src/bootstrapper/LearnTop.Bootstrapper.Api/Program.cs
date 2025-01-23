using LearnTop.Bootstrapper.Api.Extensions;
using LearnTop.Bootstrapper.Api.Middlewares;
using LearnTop.Modules.Academy.Infrastructure;
using LearnTop.Modules.Blogs.Infrastructure;
using LearnTop.Modules.Requests.Infrastructure;
using LearnTop.Modules.Users.Infrastructure;
using LearnTop.Shared.Application;
using LearnTop.Shared.Infrastructure;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.OpenApi.Models;
using Serilog;
using Tagging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header, 
            Description = "Please enter token", 
            Name = "Authorization",
            Type = SecuritySchemeType.Http, 
            BearerFormat = "JWT", 
            Scheme = "Bearer"
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
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
        (LearnTop.Modules.Academy.Application.AssemblyReference.AcademyAssembly,
        LearnTop.Modules.Users.Application.AssemblyReference.UsersAssembly,
        LearnTop.Modules.Blogs.Application.AssemblyReference.BlogsAssembly,
        LearnTop.Modules.Requests.Application.AssemblyReference.RequestsAssembly,
        Tagging.AssemblyReference.TaggingAssembly)
    
    .AddInfrastructureConfiguration(
        builder.Configuration.GetConnectionString("Cache")!);

builder.Services
    .AddAcademyModule(builder.Configuration)
    .AddUsersModule(builder.Configuration)
    .AddBlogsModule(builder.Configuration)
    .AddRequestsModule(builder.Configuration)
    .AddTaggingModule(builder.Configuration);

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
