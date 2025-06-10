using LearnTop.Modules.Academy.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Identity.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Requests.Infrastructure.WriteDb;
using LearnTop.Modules.Users.Infrastructure.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Bootstrapper.Api.Extensions;

internal static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<BlogsDbContext>(scope);
        ApplyMigration<IdentityDbContext>(scope);
        ApplyMigration<RequestsDbContext>(scope);
        ApplyMigration<UsersDbContext>(scope);
        ApplyMigration<InformationDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
