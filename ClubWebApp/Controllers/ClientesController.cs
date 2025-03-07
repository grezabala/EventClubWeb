using AutoMapper;
using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Infraestructura.Services.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace ClubWebApp.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper;

        public ClientesController(IClientesService clientesService, IMapper mapper)
        {
            _clientesService = clientesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var _list = await _clientesService.GetClientesAsync();
                var _listDto = new List<ClientesDto>();

                foreach (var _cliente in _list) 
                {
                    _listDto.Add(_mapper.Map<ClientesDto>(_cliente));               
                }

                if(_listDto == null)
                    return NotFound();

                return View(_listDto);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Registrarse() 
        {

            return View();
        }
    }
}
