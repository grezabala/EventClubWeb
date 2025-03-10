using ClubWebApp.Application.Infraestructura.Services.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace ClubWebApp.Controllers
{
    public class EventosPublicosController : Controller
    {
        private readonly IEventosPublicos _eventosPublicos;
        public EventosPublicosController(IEventosPublicos eventosPublicos)
        {
            _eventosPublicos = eventosPublicos;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _eventosPublicos.GetEventosPublicosAsync();

                if (list == null) 
                {
                  return NotFound();
                }

                return View(list);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
