using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Dominio.Entities;
using FluentValidation;

namespace ClubWebApp.Application.Infraestructura.ValidatorEntities
{
    public class EventosValidator : AbstractValidator<POSTCreadEventosDto>
    {
        public EventosValidator()
        {
            RuleFor(p => p.ClienteId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Este campo es requerido");

            RuleFor(p => p.Ubicacion)
                .NotNull()
                .NotEmpty()
                .WithMessage("Este campo es requerido")
                .Length(2, 250);

            RuleFor(p => p.Descripcion)
                .NotEmpty()
                .WithMessage("Este campo es requerido")
                .Length(2, 250);

            RuleFor(p => p.Cantidad_Personas)
                .NotNull()
                .NotEmpty()
                .WithMessage("Este campo es requerido");

            RuleFor(p => p.Nombre)
                .NotNull()
                .NotEmpty()
                .WithMessage("Este campo es requerido")
                .Length(5, 100);

            RuleFor(p => p.Salon)
                .NotNull()
                .NotEmpty()
                .WithMessage("Este campo es requerido")
                .Length(2, 20);

            RuleFor(p => p.Numero_Salon)
                .NotNull()
                .NotEmpty()
                .WithMessage("Este campo es requerido")
                .Length(2, 50);

            RuleFor(p => p.Codigo)
                .NotEmpty()
                .WithMessage("Este campo es requerido")
                .Length(2, 20);

        }
    }

}
