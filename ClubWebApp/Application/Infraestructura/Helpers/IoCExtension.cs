using ClubWebApp.Aplication.Dominio.Contexts;
using ClubWebApp.Aplication.Dominio.Data.DbConnectionSql;
using ClubWebApp.Application.Dominio.Repository;
using ClubWebApp.Application.Infraestructura.Mappers;
using ClubWebApp.Application.Infraestructura.Services.Interfaz;
using ClubWebApp.Application.Infraestructura.ValidatorEntities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClubWebApp.Aplication.Infraestructura.Helpers
{
    public static class IoCExtension
    {
        public static IServiceCollection Configuration(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {

            return serviceDescriptors.Configuration(configuration);
        }

        //Conexion al motor de base de datos o motores de base de datos
        public static IServiceCollection ConnectionDbClubApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClubWebApplicationDbContext>(sql =>
            {
                sql.UseSqlServer(@"Data Source=(local); Initial Catalog=ClubAltamaria; Integrated Security=True; MultipleActiveResultSets=True; Encrypt=True; TrustServerCertificate=True",
                sqlOpt =>
                {
                    sqlOpt.EnableRetryOnFailure();
                    sqlOpt.UseNetTopologySuite();

                });

                sql.UseLazyLoadingProxies();

            });

            services.AddTransient<ClubWebApplicationDbContext>();

            return services;

        }

        //Services
        public static IServiceCollection AddServiceCluApplication(this IServiceCollection services)
        {
            services.AddScoped<ClubWebApplicationDbContext>();

            services.AddAutoMapper(typeof(ClubWebAppMappers).Assembly);

            services.AddScoped<IEventosService, EventosRepoService>();
            services.AddScoped<IClientesService, ClientesRepoService>();



            //services.AddValidatorFromAssemblyContaining<EventosValidator>();
            //services.AddValidatorsFromAssemblyContanining(typeof(EventosValidator));
            services.AddScoped<ConnectionSqlServer>();



            return services;

        }
    }
}
