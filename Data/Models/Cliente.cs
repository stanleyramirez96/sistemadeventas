using Microsoft.Extensions.Hosting;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Models;

public class Cliente
{
    public Cliente()
    {
        Ventas = new List<Venta>(); 
    }
    [Key]
    public int ID { get; set; }
    public string NombreC { get; set; } = null!;
    public string? Apellido { get; set; }
    public string? Telefono { get; set; }
    public string? Cedula { get; set; }
    public string? Direccion { get; set; }

    public static Cliente Crear(ClienteRequest cliente) => new Cliente()
    {
        NombreC= cliente.NombreC,
        Apellido= cliente.Apellido,
        Telefono= cliente.Telefono,
        Cedula= cliente.Cedula,
        Direccion= cliente.Direccion
    };
    public bool Modificar(ClienteRequest cliente)
    {

         var  cambio = false;
        if (NombreC != cliente.NombreC)
        {

            NombreC = cliente.NombreC;
            cambio = true;

        }
        if (Apellido != cliente.Apellido)
        {

            Apellido = cliente.Apellido;
            cambio = true;
        }
        if (Telefono != cliente.Telefono)
        {
            Telefono = cliente.Telefono;
            cambio = true;
        }

        if (Cedula != cliente.Cedula)
        {
            Cedula = cliente.Cedula;
            cambio = true;
        }
        if (Direccion != cliente.Direccion)
        {
            Direccion = cliente.Direccion;
            cambio = true;
        }
        return cambio;
    }
    public ClienteResponse ToResponse() => new ClienteResponse()
    {
        ID = ID,
        NombreC = NombreC,
        Apellido = Apellido,
        Telefono = Telefono,
        Cedula= Cedula,
        Direccion= Direccion


    };
    public virtual ICollection<Venta> Ventas { get; set; }
}
