using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Context;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;

public interface IClienteServices
{
    Task<Result<List<ClienteResponse>>> Consultar(string filtro);
    Task<Result> Crear(ClienteRequest request);
    Task<Result> Eliminar(ClienteRequest request);
    Task<Result> Modificar(ClienteRequest request);
}

public class ClienteServices : IClienteServices1
{

    private readonly ISistemaDeVentasDbContext dbcontext;

    public ClienteServices(ISistemaDeVentasDbContext dbcontext)
    {
        this.dbcontext = dbcontext;

    }
    public async Task<Result> Crear(ClienteRequest request)
    {


        try
        {
            var cliente = Cliente.Crear(request);
            dbcontext.Clientes.Add(cliente);
            await dbcontext.SaveChangesAsync();
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(ClienteRequest request)
    {


        try
        {
            var cliente = await dbcontext.Clientes.FirstOrDefaultAsync(c => c.ID == request.ID);
            if (cliente == null)
                return new Result { Message = "No se encontro un usuario", Success = false };
            if (cliente.Modificar(request))
                await dbcontext.SaveChangesAsync();
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(ClienteRequest request)
    {


        try
        {
            var cliente = await dbcontext.Clientes.FirstOrDefaultAsync(c => c.ID == request.ID);
            if (cliente == null)
                return new Result { Message = "No se encontro un usuario", Success = false };
            dbcontext.Clientes.Remove(cliente);
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }

    public async Task<Result<List<ClienteResponse>>> Consultar(string filtro)
    {
        try
        {
            var cliente = await dbcontext.Clientes.Where(c => (c.NombreC + "" + c.Apellido + "" + c.Telefono + "" + c.Cedula + "" + c.Direccion)
            .ToLower().Contains(filtro.ToLower())
            ).Select(c => c.ToResponse()).ToListAsync();
            return new Result<List<ClienteResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = cliente
            };
        }
        catch (Exception ex)
        {
            return new Result<List<ClienteResponse>>
            {
                Message = ex.Message,
                Success = true,

            };
        }
    }


}
