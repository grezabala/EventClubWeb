namespace ClubWebApp.Application.Dominio.DTOS
{
    public class ClientesDto
    {
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
