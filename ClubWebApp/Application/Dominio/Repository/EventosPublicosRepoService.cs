using ClubWebApp.Aplication.Dominio.Contexts;
using ClubWebApp.Aplication.Dominio.Data.DbConnectionSql;
using ClubWebApp.Application.Dominio.DTOS;
using ClubWebApp.Application.Dominio.Entities;
using ClubWebApp.Application.Infraestructura.Services.Interfaz;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace ClubWebApp.Application.Dominio.Repository
{
    public class EventosPublicosRepoService : IEventosPublicos
    {

        private readonly ConnectionSqlServer _connectionSqlServer;

        public EventosPublicosRepoService(ConnectionSqlServer connectionSqlServer)
        {
            _connectionSqlServer = connectionSqlServer;
          
        }
       
        public async Task<ICollection<EventosPublicosDto>> GetEventosPublicosAsync()
        {
            var list = new List<EventosPublicosDto>();
            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("", cn);
            try
            {
                await cn.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var _eventoPublico = new EventosPublicosDto()
                    {
                        EventoPublicoId = reader.GetInt32(reader.GetOrdinal("EventoPublicoId")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Lugar = reader.GetString(reader.GetOrdinal("Lugar")),
                        Atracciones = reader.GetString(reader.GetOrdinal("Atracciones")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                        Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                        Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                        Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                        HoraInicio = reader.GetString(reader.GetOrdinal("HoraInicio")),
                        HoraFinalizacion = reader.GetString(reader.GetOrdinal("HoraFinalizacion"))

                    };

                    list.Add(_eventoPublico);

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener los eventos", ex);
            }

            return list;
        }

        public async Task<EventosPublicosDto> GetEventosPublicosAsync(int Id)
        {
            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("", cn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("", Id);

                await cn.OpenAsync();

                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var _eventoPublico = new EventosPublicosDto()
                    {
                        EventoPublicoId = reader.GetInt32(reader.GetOrdinal("EventoPublicoId")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Lugar = reader.GetString(reader.GetOrdinal("Lugar")),
                        Atracciones = reader.GetString(reader.GetOrdinal("Atracciones")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                        Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                        Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                        Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                        HoraInicio = reader.GetString(reader.GetOrdinal("HoraInicio")),
                        HoraFinalizacion = reader.GetString(reader.GetOrdinal("HoraFinalizacion"))

                    };

                    return _eventoPublico;

                }
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }

        public async Task<bool> IsCreadAsync(POSTEventosPublicosDto pOST)
        {
            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("", cn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@ClienteId", SqlDbType.Int) { Value = pOST.ClienteId });
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 250) { Value = pOST.Nombre });
                cmd.Parameters.Add(new SqlParameter("@Lugar", SqlDbType.VarChar, 250) { Value = pOST.Lugar });
                cmd.Parameters.Add(new SqlParameter("@Atracciones", SqlDbType.VarChar, 250) { Value = pOST.Atracciones });
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = pOST.Descripcion });
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime2) { Value = pOST.Fecha });
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 250) { Value = pOST.Tipo });
                cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 250) { Value = pOST.Direccion });
                cmd.Parameters.Add(new SqlParameter("@HoraInicio", SqlDbType.VarChar, 20) { Value = pOST.HoraInicio });
                cmd.Parameters.Add(new SqlParameter("@HoraFinalizacion", SqlDbType.VarChar, 20) { Value = pOST.HoraFinalizacion });

                await cn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsDeletedAsync(int Id)
        {
            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("", cn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@EventoPublicoId", SqlDbType.Int) { Value = Id });

                await cn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsEditedAsync(PUTEventosPublicosDto pUT)
        {

            using var cn = new SqlConnection(_connectionSqlServer.GetConexion());
            using var cmd = new SqlCommand("", cn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EventoPublicoId", pUT.EventoPublicoId);

                cmd.Parameters.Add(new SqlParameter("@EventoPublicoId", SqlDbType.Int) { Value = pUT.EventoPublicoId });
                cmd.Parameters.Add(new SqlParameter("@ClienteId", SqlDbType.Int) { Value = pUT.ClienteId });
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 250) { Value = pUT.Nombre });
                cmd.Parameters.Add(new SqlParameter("@Lugar", SqlDbType.VarChar, 250) { Value = pUT.Lugar });
                cmd.Parameters.Add(new SqlParameter("@Atracciones", SqlDbType.VarChar, 250) { Value = pUT.Atracciones });
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = pUT.Descripcion });
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime2) { Value = pUT.Fecha });
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 250) { Value = pUT.Tipo });
                cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 250) { Value = pUT.Direccion });
                cmd.Parameters.Add(new SqlParameter("@HoraInicio", SqlDbType.VarChar, 20) { Value = pUT.HoraInicio });
                cmd.Parameters.Add(new SqlParameter("@HoraFinalizacion", SqlDbType.VarChar, 20) { Value = pUT.HoraFinalizacion });

                await cn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
