using Microsoft.AspNetCore.Mvc;

namespace ClubWebApp.Controllers
{
    public class LoginClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login() 
        {
            return View();
        
        }
    }
}
