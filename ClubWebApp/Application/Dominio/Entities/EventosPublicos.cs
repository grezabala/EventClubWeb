using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Application.Dominio.Entities
{
    public class EventosPublicos
    {
        [Key]
        public int EventoPublicoId { get; set; }
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public string Atracciones { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinalizacion { get; set; }
        public string Name_Cliente { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime IsDeletedAt { get; set; }
        public bool IsDeletedBy { get; set; }
        public DateTime IsUpdatedAt { get; set; }
        public bool IsUpdatedBy { get; set; }
    }
}
