using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Dominio.Entities;
using FluentValidation;

namespace ClubWebApp.Application.Infraestructura.ValidatorEntities
{
    public class EventosValidator : AbstractValidator<POSTCreadEventosDto>
    {
        public EventosValidator()
        {
            RuleFor(p => p.ClienteId).NotNull().NotEmpty().WithMessage("Este campo es requerido");
            RuleFor(p => p.Ubicacion).NotNull().NotEmpty().Length(2, 250).WithMessage("Este campo es requerido");
            RuleFor(p => p.Descripcion).NotEmpty().Length(2, 250).WithMessage("Este campo es requerido");
            RuleFor(p => p.Cantidad_Personas).NotNull().NotEmpty().WithMessage("Este campo es requerido");
            RuleFor(p => p.Nombre).NotNull().NotEmpty().Length(5, 100).WithMessage("Este campo es requerido");
            RuleFor(p => p.Salon).NotNull().NotEmpty().Length(2, 20).WithMessage("Este campo es requerido");
            RuleFor(p => p.Numero_Salon).NotNull().NotEmpty().Length(2, 50).WithMessage("Este campo es requerido");
            RuleFor(p => p.Codigo).NotEmpty().Length(2, 20).WithMessage("Este campo es requerido");

        }
    }

}
