using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Application.Dominio.DTOS
{
    public class ClientesDto
    {
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string PasswordUser { get; set; }
        public string ConfirmarPasswordUser { get; set; }
    }

    public class POSTClientesDto
    {
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string PasswordUser { get; set; }
        public string ConfirmarPasswordUser { get; set; }
        public bool IsStatu { get; set; }
    }
}
