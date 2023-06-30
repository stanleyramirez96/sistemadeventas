using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Context;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ClienteServices : IClienteServices
{

    private readonly ISistemaDeVentasDbContext dbcontext;

    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

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
            return new Result { Message = "Cliente creado correctamente", Success = true };
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
                return new Result { Message = "No se encontró el cliente", Success = false };

            // Modificar los campos individuales del cliente
            cliente.NombreC = request.NombreC;
            cliente.Apellido = request.Apellido;
            cliente.Cedula = request.Cedula;
            cliente.Telefono = request.Telefono;
            cliente.Direccion = request.Direccion;

            await dbcontext.SaveChangesAsync(); // Guardar cambios en la base de datos
            return new Result { Message = "Cliente modificado correctamente", Success = true };
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
                return new Result { Message = "No se encontró el cliente", Success = false };

            dbcontext.Clientes.Remove(cliente);
            await dbcontext.SaveChangesAsync(); // Guardar cambios en la base de datos
            return new Result { Message = "Cliente eliminado correctamente", Success = true };
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
            var clientes = await dbcontext.Clientes
                .Where(c => (c.NombreC + " " + c.Apellido + " " + c.Telefono + " " + c.Cedula + " " + c.Direccion)
                    .ToLower().Contains(filtro.ToLower()))
                .Select(c => c.ToResponse())
                .ToListAsync();

            return new Result<List<ClienteResponse>>
            {
                Message = "Consulta exitosa",
                Success = true,
                Data = clientes
            };
        }
        catch (Exception ex)
        {
            return new Result<List<ClienteResponse>>
            {
                Message = ex.Message,
                Success = false
            };
        }
    }
}
