using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Application.Dominio.Entities
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Activo { get; set; }
        public bool IsStatu { get; set; }
        public bool IsDeletedBy { get; set; }
        public DateTime IsDeletedAt { get; set; }
        public bool IsUpdatedBy { get; set; }
        public bool IsUpdatedAt { get; set; }

        //parte del registro
        public string Usuario { get; set; }
        public string PasswordUser { get; set; }
    }
}
