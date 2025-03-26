using ClubWebApp.Application.Dominio.DTOS;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ClubWebApp.Application.Infraestructura.ValidatorEntities
{
    public class ClientesValidator : AbstractValidator<POSTClientesDto>
    {
        public ClientesValidator()
        {
            RuleFor(cliente => cliente.Codigo)
             .NotEmpty().WithMessage("El código es obligatorio.")
             .MaximumLength(50).WithMessage("El código no puede tener más de 50 caracteres.");

            RuleFor(cliente => cliente.NombreCompleto)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre completo no puede tener más de 200 caracteres.");

            RuleFor(cliente => cliente.Cedula)
                .NotEmpty().WithMessage("La cédula es obligatoria.")
                .Must(ValidarCedula).WithMessage("La cédula no es válida.")
                .MaximumLength(11).WithMessage("La cédula no puede tener más de 11 caracteres.");

            RuleFor(cliente => cliente.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(20).WithMessage("El teléfono no puede tener más de 20 caracteres.");

            RuleFor(cliente => cliente.Celular)
                .NotEmpty().WithMessage("El celular es obligatorio.")
                .MaximumLength(20).WithMessage("El celular no puede tener más de 20 caracteres.");

            RuleFor(cliente => cliente.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("Ingrese un correo electrónico válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede tener más de 100 caracteres.");

            RuleFor(cliente => cliente.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(250).WithMessage("La dirección no puede tener más de 250 caracteres.");

            RuleFor(cliente => cliente.FechaIngreso)
                .NotEmpty().WithMessage("La fecha de ingreso es obligatoria.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de ingreso no puede ser futura.");

            //RuleFor(cliente => cliente.PasswordUser)
            //    .NotEmpty().WithMessage("La contraseña es obligatoria.")
            //    .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
            //    .Matches(@"[A-Z]+").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
            //    .Matches(@"[a-z]+").WithMessage("La contraseña debe contener al menos una letra minúscula.")
            //    .Matches(@"[0-9]+").WithMessage("La contraseña debe contener al menos un número.")
            //    .Matches(@"[\!\?\*\.\@\#\$\%\^\&\(\)\_\+\-\=\[\]\{\}\;\:\'\""\\\|\,\<\>\/\`\~]+").WithMessage("La contraseña debe contener al menos un carácter especial.");

            RuleFor(cliente => cliente.ConfirmarPasswordUser)
                .NotEmpty().WithMessage("La confirmación de contraseña es obligatoria.")
                .Equal(cliente => cliente.PasswordUser).WithMessage("Las contraseñas no coinciden.");


        }

        private bool ValidarCedula(string cedula) 
        {

            if (string.IsNullOrEmpty(cedula)) return false;

            cedula = cedula.Replace("-", "");

            if(cedula.Length != 11 || !Regex.IsMatch(cedula, @"^\d+$.")) return false;

            int verificador = int.Parse(cedula.Substring(10, 1));
            int suma = 0;

            for (int i = 0; i < 10; i++) 
            {
                int digito = int.Parse(cedula.Substring(i, 1));
                if (i % 2 == 0) 
                {
                    digito *= 2;
                    if(digito > 9) digito -= 9;
                
                }
                suma += digito;
            
            }

            return (10 - (suma % 10)) % 10 == verificador;
        
        }
    }
}
