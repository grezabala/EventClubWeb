using ClubWebApp.Aplication.Infraestructura.Helpers;
using ClubWebApp.Application.Infraestructura.Filtros;
using ClubWebApp.Application.Infraestructura.ValidatorEntities;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

//Add Configuration
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar el almacenamiento de sesión en memoria
builder.Services.AddDistributedMemoryCache();

//Soperte para la sesión
//builder.Services.AddSession();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(35);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});

// Habilitar acceso a HttpContext en los controladores y filtros
builder.Services.AddHttpContextAccessor();

// Agregar servicios de MVC
builder.Services.AddControllersWithViews();


//Service Helpers
builder.Services.ConnectionDbClubApplication(configuration);
builder.Services.AddServiceCluApplication();

//builder.Services.AddValidatorFromAssemblyContaining<EventosValidator>();
//builder.Services.AddValidatorsFromAssemblyContanining(typeof(EventosValidator));

//builder.Services.AddValidatorsFromAssemblyContaining<EventosValidator>();

//Validacion del modelo
builder.Services.AddValidatorsFromAssemblyContaining<EventosValidator>();

//Filter
//builder.Services.AddSession();


//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(40);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;


//});

builder.Services.AddScoped<AuthFilter>();

////Acceso a HttpContext
//builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//Para habilitar la session
app.UseSession();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
