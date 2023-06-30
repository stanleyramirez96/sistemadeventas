using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Context;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;


public class VentaServices : IVentaServices
{

    private readonly ISistemaDeVentasDbContext dbContext;
    public VentaServices(ISistemaDeVentasDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<List<VentaResponse>>> Consultar()
    {
        try
        {
            var Ventas = await dbContext.Ventas
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                .ThenInclude(d => d.Producto)
                .Select(f => f.ToResponse())
                .ToListAsync();
            return new Result<List<VentaResponse>>()
            {
                Data = Ventas,
                Success = true,
                Message = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<List<VentaResponse>>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
        }
    }
    public async Task<Result<VentaResponse>> Crear(VentaRequest request)
    {
        try
        {
            var nuevaVenta = Venta.Crear(request);
            dbContext.Ventas.Add(nuevaVenta);
            await dbContext.SaveChangesAsync();
            return new Result<VentaResponse>()
            {
                Data = nuevaVenta.ToResponse(),
                Success = true,
                Message = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<VentaResponse>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
        }
    }


    public async Task<Result<List<ClienteResponse>>> ConsultarClientes()
    {
        try
        {
            var clientes = await dbContext.Clientes.ToListAsync();
            var clientesResponse = clientes.Select(c => c.ToResponse()).ToList();

            return new Result<List<ClienteResponse>>()
            {
                Data = clientesResponse,
                Success = true,
                Message = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<List<ClienteResponse>>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
        }
    }

    public async Task<Result<List<ProductoResponse>>> ConsultarProductos()
    {
        try
        {
            var productos = await dbContext.Productos.ToListAsync();
            var productosResponse = productos.Select(p => p.ToResponse()).ToList();

            return new Result<List<ProductoResponse>>()
            {
                Data = productosResponse,
                Success = true,
                Message = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<List<ProductoResponse>>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
        }
    }



}

