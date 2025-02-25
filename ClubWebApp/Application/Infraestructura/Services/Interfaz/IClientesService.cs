using ClubWebApp.Application.Dominio.Entities;

namespace ClubWebApp.Application.Infraestructura.Services.Interfaz
{
    public interface IClientesService
    {
        Task<ICollection<Clientes>> GetClientesAsync();
        Task<Clientes> GetClientesByIdAsync(int clienteId);
        Task<bool> IsCreadAsync(Clientes clientes);
        Task<bool> IsEditedAsync(int clienteId, Clientes clientes);
        Task<bool> IsDeletedAsync(int clienteId);
    }
}
