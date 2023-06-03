using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Context;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;

public class VentaServicesBase
{

    private readonly ISistemaDeVentasDbContext dbcontext;

    public async Task<Result<List<VentaResponse>>> Consultar(string filtro)
    {
        try
        {
            var venta = await dbcontext.Ventas.Where(c => (c.ID + "" + c.Cliente + "" + c.UsuarioId + "" + c.Fecha)
            .ToLower().Contains(filtro.ToLower())
            ).Select(c => c.ToResponse()).ToListAsync();
            return new Result<List<VentaResponse>>()
            {

                Message = "Ok",
                Success = true,

            };
        }
        catch (Exception ex)
        {
            return new Result<List<VentaResponse>>
            {
                Message = ex.Message,
                Success = true,

            };
        }
    }
    public async Task<Result> Crear(VentaRequest request)
    {


        try
        {
            var venta = Venta.Crear(request);
            dbcontext.Ventas.Add(venta);
            await dbcontext.SaveChangesAsync();
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(VentaRequest request)
    {


        try
        {
            var venta = await dbcontext.Ventas.FirstOrDefaultAsync(c => c.ID == request.ID);
            if (venta == null)
                return new Result { Message = "No se encontro un usuario", Success = false };
            dbcontext.Ventas.Remove(venta);
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(VentaRequest request)
    {


        try
        {
            var venta = await dbcontext.Ventas.FirstOrDefaultAsync(c => c.ID == request.ID);
            if (venta == null)
                return new Result { Message = "No se encontro un usuario", Success = false };
            if (venta.Modificar(request))
                await dbcontext.SaveChangesAsync();
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }
}