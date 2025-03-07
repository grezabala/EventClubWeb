using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Application.Dominio.DTOS
{
    public partial class EventosDto
    {
        public int ID { get; set; }
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Evento { get; set; }
        public string Salon { get; set; }
        public string Numero_Salon { get; set; }
        public string Ubicacion { get; set; }
        public int Cantidad_Personas { get; set; }
        public string Nombre { get; set; }
    }

    public partial class POSTCreadEventosDto
    {  
        public int ClienteId { get; set; }
        public string Codigo { get; set; }    
        public string Descripcion { get; set; }
        public DateTime Fecha_Evento { get; set; }
        public string Salon { get; set; }
        public string Numero_Salon { get; set; }
        public string Ubicacion { get; set; }
        public string Cantidad_Personas { get; set; }
        public string Nombre { get; set; }
    }

    public partial class POSTUpdateEventosDto
    {
        public int ID { get; set; }
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_Evento { get; set; }
        public string Salon { get; set; }
        public string Numero_Salon { get; set; }
        public string Ubicacion { get; set; }
        public string Cantidad_Persona { get; set; }                                                                                                                 
        public string Nombre { get; set; }
    }


}
