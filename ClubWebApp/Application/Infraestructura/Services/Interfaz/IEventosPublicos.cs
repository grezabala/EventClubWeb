using ClubWebApp.Application.Dominio.DTOS;

namespace ClubWebApp.Application.Infraestructura.Services.Interfaz
{
    public interface IEventosPublicos
    {
        Task<ICollection<EventosPublicosDto>> GetEventosPublicosAsync();    
        Task<EventosPublicosDto> GetEventosPublicosAsync(int Id);
        Task<bool> IsCreadAsync(POSTEventosPublicosDto pOST);
        Task<bool> IsEditedAsync(PUTEventosPublicosDto pUT);
        Task<bool> IsDeletedAsync(int Id);
    }
}
