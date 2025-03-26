using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Dominio.Entities;
using ClubWebApp.Models;

namespace ClubWebApp.Application.Infraestructura.Services.Interfaz
{
    public interface IClientesService
    {
        Task<ICollection<Clientes>> GetClientesAsync();
        Task<Clientes> GetClientesByIdAsync(int clienteId);
        Task<bool> IsCreadAsync(POSTClientesDto clientes);
        Task<bool> IsEditedAsync(int clienteId, Clientes clientes);
        Task<bool> IsDeletedAsync(int clienteId);
        Task<Clientes> GetClientesRegistradoAsync(LoginViewModel loginViewModel);
        Task<bool> IsExisteEmail(string email);
    }
}
