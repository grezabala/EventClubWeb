using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClubWebApp.Application.Infraestructura.Filtros
{
    public class AuthFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var session = context.HttpContext.Session;
            //var email = session.GetString("email");

            var email = _httpContextAccessor.HttpContext?.Session.GetString("email");

            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToActionResult("Login", "Clientes", null);
            }
        }
    }
}
