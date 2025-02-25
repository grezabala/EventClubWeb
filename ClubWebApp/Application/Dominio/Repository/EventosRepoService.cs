using ClubWebApp.Aplication.Dominio.Contexts;
using ClubWebApp.Aplication.Dominio.Data.DbConnectionSql;
using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Infraestructura.Services.Interfaz;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubWebApp.Application.Dominio.Repository
{
    public class EventosRepoService : IEventosService
    {
        private readonly ConnectionSqlServer _connectionSqlServer;
        private readonly ClubWebApplicationDbContext _databaseContext;

        public EventosRepoService(ConnectionSqlServer connectionSqlServer, ClubWebApplicationDbContext clubWebApplicationDbContext)
        {
            this._connectionSqlServer = connectionSqlServer;
            this._databaseContext = clubWebApplicationDbContext;
        }

        public async Task<bool> CreadAsync(POSTCreadEventosDto eventosDto)
        {
            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("pro_AddEventos", cn);
            try
            {
                var random = new Random().Next(1,9999);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int) { Value = eventosDto.IdCliente });
                cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar, 20) { Value = eventosDto.Codigo });
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = eventosDto.Descripcion });
                cmd.Parameters.Add(new SqlParameter("@Fecha_Evento", SqlDbType.DateTime) { Value = eventosDto.Fecha_Evento });
                cmd.Parameters.Add(new SqlParameter("@Salon", SqlDbType.VarChar, 50) { Value = eventosDto.Salon });
                cmd.Parameters.Add(new SqlParameter("@Numero_Salon", SqlDbType.VarChar, 10) { Value = eventosDto.Numero_Salon });
                cmd.Parameters.Add(new SqlParameter("@Ubicacion", SqlDbType.VarChar, 250) { Value = eventosDto.Ubicacion });
                cmd.Parameters.Add(new SqlParameter("@Cantidad_Personas", SqlDbType.Int) { Value = eventosDto.Cantidad_Personas });
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = eventosDto.Nombre });

                await cn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        public async Task<EventosDto> DeleteAsync(int eventoId)
        {

            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("pro_DeleteEventoId", cn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = eventoId
                });

                await cn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return new EventosDto
                {
                    ID = eventoId,
                };
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al ejecutar el procedimiento almacenado", ex);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }

        }

        public async Task<ICollection<EventosDto>> GetEventosAsync()
        {
            var eventosList = new List<EventosDto>();
            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("pro_SelectEventos", cn);
            try
            {
                await cn.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;

                var random = new Random().Next(1, 999999999);
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var evento = new EventosDto
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        IdCliente = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                        Fecha_Evento = reader.GetDateTime(reader.GetOrdinal("Fecha_Evento")),
                        Cantidad_Personas = reader.GetInt32(reader.GetOrdinal("Cantidad_Personas")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                        Numero_Salon = reader.GetString(reader.GetOrdinal("Numero_Salon")),
                        Salon = reader.GetString(reader.GetOrdinal("Salon")),
                        Ubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"))

                    };

                    eventosList.Add(evento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener eventos", ex);
            }

            return eventosList;
        }
        public async Task<ICollection<EventosDto>> GetEventosByCodeAsync(string code)
        {
            try
            {
                IQueryable<EventosDto> query = _databaseContext.Set<EventosDto>().AsQueryable();
                if (!string.IsNullOrEmpty(code))
                    query = query.Where(x => x.Codigo.Contains(code.ToLower().Trim()) == x.Codigo.Contains(code.ToLower().Trim()));

                return await query.OrderBy(x => x.IdCliente).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR...! No fue posible mostrar el Evento, el código ingresado no existe."
                    + "Por favor verificar que el código es correcto", ex);
            }
        }

        public async Task<EventosDto> GetEventosByIdAsync(int eventoId)
        {
            try
            {
                var evento = await _databaseContext.Set<EventosDto>()
                    .FirstOrDefaultAsync(x => x.ID == eventoId);

                if (evento == null) 
                {
                    throw new KeyNotFoundException("El Evento no fue encontrado." + "Por favor validar que el ID existe o es el correcto.");
                }

                return evento;
                    
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR...! No fue posible mostrar el Evento, el ID ingresado no existe."
                    + "Por favor verificar que el ID es correcto", ex);
            }
        }

        public async Task<ICollection<EventosDto>> GetEventosByNameAsync(string name)
        {
            try
            {
                IQueryable<EventosDto> query = _databaseContext.Set<EventosDto>().AsQueryable();
                if (!string.IsNullOrEmpty(name))
                    query = query.Where(x => x.Nombre.Contains(name.ToLower().Trim()) == x.Descripcion.Contains(name.ToLower().Trim()));

                return await query.OrderBy(x => x.Fecha_Evento)
                    .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("ERROR...!");
            }
        }

        public async Task<bool> UpdateAsync(EventosDto eventosDto)
        {
            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("pro_AddEventos", cn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int) { Value = eventosDto.IdCliente });
                cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar, 20) { Value = eventosDto.Codigo });
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = eventosDto.Descripcion });
                cmd.Parameters.Add(new SqlParameter("@Fecha_Evento", SqlDbType.DateTime) { Value = eventosDto.Fecha_Evento });
                cmd.Parameters.Add(new SqlParameter("@Salon", SqlDbType.VarChar, 50) { Value = eventosDto.Salon });
                cmd.Parameters.Add(new SqlParameter("@Numero_Salon", SqlDbType.VarChar, 10) { Value = eventosDto.Numero_Salon });
                cmd.Parameters.Add(new SqlParameter("@Ubicacion", SqlDbType.VarChar, 250) { Value = eventosDto.Ubicacion });
                cmd.Parameters.Add(new SqlParameter("@Cantidad_Personas", SqlDbType.Int) { Value = eventosDto.Cantidad_Personas });
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100) { Value = eventosDto.Nombre });

                await cn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }
    }
}
