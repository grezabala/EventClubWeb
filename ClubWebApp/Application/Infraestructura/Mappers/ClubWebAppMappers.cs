using AutoMapper;
using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Dominio.Entities;

namespace ClubWebApp.Application.Infraestructura.Mappers
{
    public class ClubWebAppMappers : Profile
    {
        public ClubWebAppMappers()
        {
            CreateMap<Clientes, ClientesDto>().ReverseMap(); 
        }
    }
}
