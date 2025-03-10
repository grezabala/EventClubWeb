using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClubWebApp.Application.Infraestructura.Filtros
{
    public class ValidatorAccesAttribute : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Obtener la sesión
            var session = context.HttpContext.Session;
            var email = session.GetString("email");

            // Validar si el usuario está registrado (es decir, si hay sesión activa)
            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                   { "controller", "Cliente" },
                    { "action", "Login" }
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No es necesario modificar nada aquí
        }




        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    if (HttpContext..Session["usuario"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("~/Acceso/Login");
        //    }

        //    base.OnActionExecuted(filterContext);
        //}


        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    var session = context.HttpContext.Session;

        //    if (session.GetString("email") == null) 
        //    {
        //        context.Result = new RedirectResult("~/Clientes/Login");
        //    }

        //    //if (context.HttpContext.Session.GetString("email") == null) 
        //    //{
        //    //    context.Result = new RedirectResult("~/Clientes/Login");
        //    //}

        //    base.OnActionExecuted(context);

        //}
    }
}
