using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TelephoneBookDbContext>(options =>
            {
                // options.UseNpgsql(configuration.GetConnectionString("TelephoneBookDatabase"));
                options.UseSqlite(configuration.GetConnectionString("Sqlite"));
            });

            services.AddScoped<ITelephoneBookDbContext>(provider =>
                provider.GetService<TelephoneBookDbContext>());

            return services;
        }
    }
}