using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Application.Dominio.Entities
{
    public partial class Eventos
    {
        [Key]
        public int ID { get; set; }
        public int IdCliente { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Evento { get; set; }
        public string Salon { get; set; }
        public string Numero_Salon { get; set; }
        public string Ubicacion { get; set; }
        public int Cantidad_Personas { get; set; }
        public string Nombre { get; set; }
    }
}
