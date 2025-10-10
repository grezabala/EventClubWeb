using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Models
{
    public class EventoPublicoViewModal
    {
        public string Nombre_Titulo { get; set; }
        public int ClienteId { get; set; }
        public string Lugar { get; set; }
        public string Atracciones { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaHoraEvento { get; set; }

        public string TipoDeEvento { get; set; }
        public TimeSpan HoraDeInicio { get; set; }
        public TimeSpan HoraDeFinalizacion { get; set; }

    }
}
