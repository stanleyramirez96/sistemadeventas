using Microsoft.Extensions.Hosting;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Models;

public class Cliente
{
    [Key]
    public int ID { get; set; }
    public string? NombreC { get; set; }
    public string Apellido { get; set; }
    public int Telefono { get; set; }
    public int Cedula { get; set; }
    public string Direccion { get; set; }

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
        NombreC = NombreC,
        Apellido = Apellido,
        Telefono = Telefono,
        Cedula= Cedula,
        Direccion= Direccion


    };
    public virtual ICollection<Venta> Ventas { get; set; }
}
