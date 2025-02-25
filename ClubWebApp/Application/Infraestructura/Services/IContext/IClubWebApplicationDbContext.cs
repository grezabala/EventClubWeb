using ClubWebApp.Application.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubWebApp.Aplication.Infraestructura.Services.IContext
{
    public interface IClubWebApplicationDbContext
    {
        DbSet<Eventos> Eventos { get; set; }
        DbSet<Clientes> Clientes { get; set; }
    }
}
