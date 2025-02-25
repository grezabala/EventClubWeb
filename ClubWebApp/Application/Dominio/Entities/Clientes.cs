using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Application.Dominio.Entities
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string CodigoDelCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Descripcion { get; set; }
    }
}
