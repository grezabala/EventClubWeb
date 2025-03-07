using ClubWebApp.Aplication.Dominio.Contexts;
using ClubWebApp.Application.Dominio.Entities;
using ClubWebApp.Application.Infraestructura.Services.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace ClubWebApp.Application.Dominio.Repository
{
    public class ClientesRepoService(ClubWebApplicationDbContext clubWebApplicationDbContext) : IClientesService
    {
        private readonly ClubWebApplicationDbContext _context = clubWebApplicationDbContext;

        public async Task<ICollection<Clientes>> GetClientesAsync()
        {
            try
            {
                return await _context.Clientes.OrderBy(x => x.NombreCompleto).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{_getException} {ex.Message}");
            }
        }

        public async Task<Clientes> GetClientesByIdAsync(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                    throw new Exception(_getExceptionValidator);

                return await _context.Clientes.FirstOrDefaultAsync(x => x.ClienteId == clienteId);
            }
            catch (Exception ex)
            {

                throw new Exception($"{_getException} {ex.Message}");
            }
        }

        public async Task<bool> IsCreadAsync(Clientes clientes)
        {
            try
            {
                if (clientes == null)
                    throw new Exception(_addExceptionEmpty);

                if (clientes != null)
                {
                    clientes.FechaIngreso = DateTime.Now;

                    await _context.AddAsync(clientes);
                }

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                throw new Exception($"{_getException} {ex.Message}");
            }
        }

        public async Task<bool> IsDeletedAsync(int clienteId)
        {
            try
            {
                if (clienteId < 0)
                    throw new Exception(_getExceptionValidator);

                var _get = await _context.Clientes.FindAsync(clienteId);

                if (_get != null)
                {
                    _context.Clientes.Remove(_get);
                }

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                throw new Exception($"{_getException} {ex.Message}");
            }
        }

        public async Task<bool> IsEditedAsync(int clienteId, Clientes clientes)
        {
            try
            {
                if (clienteId < 0)
                    throw new Exception(_getExceptionValidator);

                if (clientes == null)
                    throw new Exception(_addExceptionEmpty);

                var _getEdit = await _context.Clientes.FindAsync(clienteId);

                if (_getEdit != null)
                {
                    _getEdit.ClienteId = clienteId;
                    _getEdit.Codigo = clientes.Codigo;
                   // _getEdit.Descripcion = clientes.Descripcion;
                    _getEdit.FechaIngreso = clientes.FechaIngreso;
                    _getEdit.Cedula = clientes.Cedula;
                    _getEdit.Celular = clientes.Celular;
                    _getEdit.Direccion = clientes.Direccion;
                    _getEdit.Email = clientes.Email;
                    _getEdit.NombreCompleto = clientes.NombreCompleto;
                    _getEdit.Telefono = clientes.Telefono;
                  
                    _context.Entry(_getEdit).State = EntityState.Modified;

                }

                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {

                throw new Exception($"{_getException} {ex.Message}");
            }
        }

        #region VARIABLE EXCEPTION
        private string _getException = "ERROR...!" + " Algo salio mal.";
        private string _getExceptionValidator = "ERROR...!" + " Algo salio mal al validar si el ID existe.";
        private string _addExceptionEmpty = "El formulario se envio vacio. " + ":" + " Por favor llenar el formulario con los datos correspondiente.";
        #endregion
    }
}
