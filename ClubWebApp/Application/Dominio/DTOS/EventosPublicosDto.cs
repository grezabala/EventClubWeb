namespace ClubWebApp.Application.Dominio.DTOS
{
    public class EventosPublicosDto
    {
        public int EventoPublicoId { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public string Atracciones { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinalizacion { get; set; }
    }

    public class POSTEventosPublicosDto
    {
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
    }

    public class PUTEventosPublicosDto
    {
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
    }
}
