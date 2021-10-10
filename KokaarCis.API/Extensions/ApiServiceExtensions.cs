using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using KokaarCis.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using KokaarCis.Utility.Options;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.Infrastructure;
using KokaarCis.Utility.Enum;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using KokaarCis.Utility.Options.Validations;
using KokaarCis.Api.Initializer;

namespace KokaarCis.Api.Extensions
{
    public static class ApiServiceExtensions
    {
        public static void ConfigureDbInitializer(this IServiceCollection services)
        {
            services.AddScoped<IDbInitializer, DbInitializer>();
        }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<LoggingOptions>(configuration.GetSection(LoggingOptions.ConfigSectionName));

            //services.Configure<DbOptions>(configuration.GetSection(DbOptions.ConfigSectionName));
            //services.TryAddSingleton<IValidateOptions<DbOptions>, DbOptionsValidation>();

            services.Configure<SuperAministratorOptions>(configuration.GetSection(SuperAministratorOptions.ConfigSectionName));
            services.TryAddSingleton<IValidateOptions<SuperAministratorOptions>, SuperAministratorOptionsValidation>();
        }

        public static void ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = new DbOptions();
            configuration.Bind(DbOptions.ConfigSectionName, dbOptions);

            if (dbOptions.ServerType == DbServerTypeEnum.Sqlite.ToString())
            {
                services.AddDbContext<ApplicationDbContext>(opts =>
                   opts.UseSqlite(configuration.GetConnectionString(dbOptions.SqliteConnectionStringName)));
            }
            else if (dbOptions.ServerType == DbServerTypeEnum.SqlServer.ToString())
            {
                services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString(dbOptions.SqlServerConnectionStringName)));
            }
        }

        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KokaarCis.API", Version = "v1" });
            });
        }
    }
}
