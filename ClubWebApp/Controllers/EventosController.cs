using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Dominio.Entities;
using ClubWebApp.Application.Infraestructura.Services.Interfaz;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ClubWebApp.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventosService _eventosService;
        private readonly IValidator<POSTCreadEventosDto> _validator;
        public EventosController(IEventosService eventosService, IValidator<POSTCreadEventosDto> validator)
        {
            this._validator = validator;
            this._eventosService = eventosService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _eventosService.GetEventosAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Cread()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cread(POSTCreadEventosDto creadEventosDto)
        {
            try
            {

                if (!ModelState.IsValid) 
                {
                    return View(creadEventosDto);
                }

                try
                {
                    await _eventosService.CreadAsync(creadEventosDto);
                    TempData["SuccessMessage"] = "Evento registrado con éxito";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError(string.Empty, "Ocurrió un error al registrar el nuevo evento");
                    return View(creadEventosDto);
                }


                //if (!ModelState.IsValid)
                //{
                //    await _eventosService.CreadAsync(creadEventosDto);
                //    TempData["notice"] = "EVENTO REGISTRADO, GRACIAS POR ELEGIRNOS!";
                //    return RedirectToAction("Index");

                //}
                //else 
                //{
                //    TempData["notice"] = "Error al registrar el evento. Revise la información proporcionada.";
                //    return RedirectToAction("Cread");
                
                //}

                //Validación del modelo
                //ValidationResult validationResult = await _validator.ValidateAsync(creadEventosDto);

                // if (!validationResult.IsValid)
                // {
                //     // Asigna los errores de validación al ModelState
                //     foreach (var error in validationResult.Errors)
                //     {
                //         ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                //     }

                //     // Retorna la vista con los errores visibles
                //     TempData["notice"] = "Error al registrar el evento. Revise la información proporcionada.";
                //     return View(creadEventosDto);
                // }

                // Registro exitoso

            }
            catch (Exception ex)
            {
                // Manejo del error genérico
                TempData["error"] = $"Ocurrió un error inesperado: {ex.Message}";
                return View(creadEventosDto);
            }
        }

    }
}
