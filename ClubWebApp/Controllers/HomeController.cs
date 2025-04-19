using ClubWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string nombre, string email, string telefono, string celular, string asunto, string mensaje)
        {

            try
            {
                //Crear el mensaje del email
                MailMessage mailMessage = new MailMessage();
                MailMessage fortCustomer = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("melendezruizgregorio@gmail.com", 587);

                //Configurar SMTP Cliente
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("", "");
                smtpClient.EnableSsl = false;

                //Configuracion del email para el servicio
                mailMessage.To.Add("greylinmelendez@gmail.com");
                mailMessage.Bcc.Add("gomezbeltranalonzo@gmail.com");
                mailMessage.From = new MailAddress(" melendez.gzm@gmail.com", "ALTA CENT");
                mailMessage.Subject = asunto;
                mailMessage.Body = GenerateServiceMailBody(nombre, email, telefono, celular, asunto, mensaje);
                mailMessage.IsBodyHtml = true;

                //Configurar correo para la cliente
                fortCustomer.To.Add(email);
                fortCustomer.From = new MailAddress("", "");
                fortCustomer.Subject = asunto;
                fortCustomer.Body = GenerateCustomerMailBody(nombre);
                fortCustomer.IsBodyHtml = true;

                //Enviar correos electrónicos
                smtpClient.Send(mailMessage);
                smtpClient.Send(fortCustomer);

                return Json("Correo enviado correctamente! Por favor, revise su correo.");

            }
            catch (SmtpException smtp)
            {

                return Json($"SMTP Error: {smtp.Message}");
            }
            catch (Exception ex)
            {
                // Log general exception
                return Json($"Error: {ex.Message}");
            }
        }

        //Plantilla para el correo del servicio
        private string GenerateServiceMailBody(string nombre, string email, string telefono, string celular, string asunto, string mensaje)
        {
            return "<table cellspacing='0' style='font-family: Arial, sans-serif; font-size: 14px;'>" +
                "<tr><td colspan='2'><strong>Hola, has recibido un nuevo mensaje desde el formulario de contacto:</strong><br/><br/></td></tr>" +

                "<tr><td style='padding: 4px 8px;'><strong>Nombre:</strong></td><td>" + nombre + "</td></tr>" +
                "<tr><td style='padding: 4px 8px;'><strong>Email:</strong></td><td>" + email + "</td></tr>" +
                "<tr><td style='padding: 4px 8px;'><strong>Teléfono:</strong></td><td>" + telefono + "</td></tr>" +
                "<tr><td style='padding: 4px 8px;'><strong>Celular:</strong></td><td>" + celular + "</td></tr>" +
                "<tr><td style='padding: 4px 8px;'><strong>Asunto:</strong></td><td>" + asunto + "</td></tr>" +
                "<tr><td style='padding: 4px 8px; vertical-align: top;'><strong>Mensaje:</strong></td><td>" + mensaje + "</td></tr>" +

                "<tr><td colspan='2'><br/>Por favor, responde a este mensaje lo antes posible.<br/><br/>¡Gracias por usar nuestro servicio!</td></tr>" +
                "</table>";
        }

        //Plantilla para el cliente
        private string GenerateCustomerMailBody(string name)
        {
            return "<table cellspacing='0' style='font-family: Arial, sans-serif; font-size: 14px;'>" +
                "<tr><td><strong>Hola " + name + ",</strong><br/><br/></td></tr>" +

                "<tr><td>Gracias por ponerte en contacto con nosotros. Hemos recibido tu mensaje y uno de nuestros asesores se comunicará contigo a la brevedad posible.</td></tr>" +

                "<tr><td style='padding-top: 15px;'>Si tienes alguna duda adicional, no dudes en escribirnos nuevamente. ¡Estamos aquí para ayudarte!</td></tr>" +

                "<tr><td style='padding-top: 25px;'>Saludos cordiales,<br/><strong>El equipo de Atención al Cliente</strong></td></tr>" +
                "</table>";
        }


        [HttpGet]
        public IActionResult Service() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Promocionales()
        {
            return View();
        
        }

        [HttpGet]
        public IActionResult Inicio() 
        {
            return View();
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
