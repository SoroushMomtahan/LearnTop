using LearnTop.Bootstrapper.Api.Extensions;
using LearnTop.Bootstrapper.Api.Middlewares;
using LearnTop.Modules.Academy.Infrastructure;
using LearnTop.Modules.Blogs.Infrastructure;
using LearnTop.Modules.Categories.Infrastructure;
using LearnTop.Modules.Commenting.Infrastructure;
using LearnTop.Modules.Files.Infrastructure;
using LearnTop.Modules.Identity.Infrastructure;
using LearnTop.Modules.Ordering.Infrastructure;
using LearnTop.Modules.Requests.Infrastructure;
using LearnTop.Modules.Users.Infrastructure;
using LearnTop.Shared.Application;
using LearnTop.Shared.Infrastructure;
using LearnTop.Shared.Presentation.Endpoints;
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("https://localhost:7014")
                .AllowAnyHeader()
                .AllowAnyMethod();
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
        LearnTop.Modules.Ordering.Application.AssemblyReference.Assembly,
        LearnTop.Modules.Files.Application.AssemblyReference.Assembly)
    
    .AddInfrastructureConfiguration(
        [BlogsModule.ConfigureConsumer],
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
    .AddOrderingModule(builder.Configuration)
    .AddFilesModule(builder.Configuration);

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
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapEndpoints();
app.MapGet("/Test", () =>
{
    return Results.Ok("Hello World!");
});
app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();
