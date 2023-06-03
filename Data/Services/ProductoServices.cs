using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Context;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;

public interface IProductoServices
{
    Task<Result<List<ProductoRequest>>> Consultar(string filtro);
    Task<Result> Crear(ProductoRequest request);
    Task<Result> Eliminar(ProductoRequest request);
    Task<Result> Modificar(ProductoRequest request);
}

public class ProductoServices : IProductoServices1
{

    private readonly ISistemaDeVentasDbContext dbcontext;

    public ProductoServices(ISistemaDeVentasDbContext dbcontext)
    {
        this.dbcontext = dbcontext;

    }
    public async Task<Result> Crear(ProductoRequest request)
    {


        try
        {
            var producto = Producto.Crear(request);
            dbcontext.Productos.Add(producto);
            await dbcontext.SaveChangesAsync();
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(ProductoRequest request)
    {


        try
        {
            var producto = await dbcontext.Productos.FirstOrDefaultAsync(c => c.ID == request.ID);
            if (producto == null)
                return new Result { Message = "No se encontro un usuario", Success = false };
            if (producto.Modificar(request))
                await dbcontext.SaveChangesAsync();
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }

    public async Task<Result> Eliminar(ProductoRequest request)
    {


        try
        {
            var producto = await dbcontext.Productos.FirstOrDefaultAsync(c => c.ID == request.ID);
            if (producto == null)
                return new Result { Message = "No se encontro un usuario", Success = false };
            dbcontext.Productos.Remove(producto);
            return new Result { Message = "Ok", Success = true };
        }
        catch (Exception ex)
        {
            return new Result { Message = ex.Message, Success = false };
        }
    }

    public async Task<Result<List<ProductoResponse>>> Consultar(string filtro)
    {
        try
        {
            var producto = await dbcontext.Productos.Where(c => (c.NombreP + "" + c.Costo + "" + c.Total + "" + c.Cantidad)
            .ToLower().Contains(filtro.ToLower())
            ).Select(c => c.ToResponse()).ToListAsync();
            return new Result<List<ProductoResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = producto
            };
        }
        catch (Exception ex)
        {
            return new Result<List<ProductoResponse>>
            {
                Message = ex.Message,
                Success = true,

            };
        }
    }


}
