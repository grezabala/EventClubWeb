using ClubWebApp.Application.Dominio.DTOS;

namespace ClubWebApp.Application.Infraestructura.Services.Interfaz
{
    public interface IEventosService
    {
        Task<ICollection<EventosDto>> GetEventosAsync();
        Task<ICollection<EventosDto>> GetEventosByCodeAsync(string code);
        Task<ICollection<EventosDto>> GetEventosByNameAsync(string name);
        Task<EventosDto> GetEventosByIdAsync(int eventoId);
        Task<bool> CreadAsync(POSTCreadEventosDto eventosDto);
        Task<bool> UpdateAsync(EventosDto eventosDto);
        Task<EventosDto> DeleteAsync(int eventoId);
    }
}
