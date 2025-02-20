using LearnTop.Bootstrapper.Api.Extensions;
using LearnTop.Bootstrapper.Api.Middlewares;
using LearnTop.Modules.Academy.Infrastructure;
using LearnTop.Modules.Blogs.Infrastructure;
using LearnTop.Modules.Categories.Infrastructure;
using LearnTop.Modules.Commenting.Infrastructure;
using LearnTop.Modules.Discounts.Infrastructure;
using LearnTop.Modules.Identity.Infrastructure;
using LearnTop.Modules.Ordering.Infrastructure;
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
        (LearnTop.Modules.Information.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Users.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Blogs.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Requests.Application.AssemblyReference.Assembly,
        Tagging.AssemblyReference.Assembly,
        LearnTop.Modules.Identity.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Commenting.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Categories.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Discounts.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Ordering.Application.AssemblyReference.Assembly)
    
    .AddInfrastructureConfiguration(
        builder.Configuration.GetConnectionString("Cache")!);

builder.Services
    .AddInformationModule(builder.Configuration)
    .AddUsersModule(builder.Configuration)
    .AddBlogsModule(builder.Configuration)
    .AddRequestsModule(builder.Configuration)
    .AddTaggingModule(builder.Configuration)
    .AddIdentityModule(builder.Configuration)
    .AddCommentingModule(builder.Configuration)
    .AddCategoriesModule(builder.Configuration)
    .AddDiscountsModule(builder.Configuration)
    .AddOrderingModule();

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
