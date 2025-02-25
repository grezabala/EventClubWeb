using ClubWebApp.Aplication.Infraestructura.Helpers;
using ClubWebApp.Application.Infraestructura.ValidatorEntities;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

//Add Configuration
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConnectionDbClubApplication(configuration);
builder.Services.AddServiceCluApplication();

//builder.Services.AddValidatorFromAssemblyContaining<EventosValidator>();
//builder.Services.AddValidatorsFromAssemblyContanining(typeof(EventosValidator));

//builder.Services.AddValidatorsFromAssemblyContaining<EventosValidator>();

//Validacion del modelo
builder.Services.AddValidatorsFromAssemblyContaining<EventosValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
