using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Infraestructura.Filtros;
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

                if (list is null || !list.Any())
                {
                    return RedirectToAction("Service","Home");
                }

                return View(list);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        //[ServiceFilter(typeof(AuthFilter))]
        public IActionResult Cread()
        {

            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Cread(POSTEventosPublicosDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NotFound("El formulario se envio vació");

                if (model == null)
                    return BadRequest(ModelState);

                if (model.ClienteId > 0)
                    return NotFound("Ingrese su ID para registrar su Evento correctamente.");

                if (!await _eventosPublicos.IsCreadAsync(model))
                    return RedirectToAction("Index");


                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {

                return StatusCode(505, ex);
            }

        }
    }
}
