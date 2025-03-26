using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Dominio.Entities;
using ClubWebApp.Application.Infraestructura.ValidatorEntities;
using FluentValidation;

namespace ClubWebApp.Application.Infraestructura.Helpers
{
    public static class IoCExtensionValidator
    {
        public static IConfiguration Configuration { get; }
        //Services Validator
        public static IServiceCollection AddValidatorClubWebApp(this IServiceCollection services)
        {
            try
            {
                services.AddScoped<IValidator<POSTCreadEventosDto>, EventosValidator>();
                services.AddScoped<IValidator<POSTClientesDto>, ClientesValidator>();

                return services;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
