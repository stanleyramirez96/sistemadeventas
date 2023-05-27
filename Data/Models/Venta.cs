using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

namespace sistemadeventas.Data.Models;

public class Venta
{
    [Key]
    public int ID { get; set; }
    public string? NombreP { get; set; }
    public string? DetalleV { get; set; }
    public int Cantidad { get; set; }
    public decimal Costo { get; set; }
    public decimal Total { get; set; }

    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

    public int ProductoId { get; set; }
    public virtual Producto Producto { get; set; }

    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
    public static Venta Crear(VentaRequest venta) => new Venta()
    {
        NombreP = venta.NombreP,
        DetalleV = venta.DetalleV,
        Cantidad = venta.Cantidad,
        Costo = venta.Costo,
        Total = venta.Total,
        UsuarioId = venta.UsuarioId,
        ProductoId = venta.ProductoId,
        ClienteId = venta.ClienteId
    };
    public bool Modificar(VentaRequest venta)
    { 
      
        var  cambio = false;
        if (NombreP != venta.NombreP)
        {

            NombreP = venta.NombreP;
            cambio = true;
        
        }
    if (DetalleV != venta.DetalleV ) {
        
        DetalleV= venta.DetalleV;
            cambio = true;
        }
        if (Cantidad != venta.Cantidad) 
        { 
            Cantidad= venta.Cantidad;
        }
    if(Costo != venta.Costo)
        {
            Costo = venta.Costo;
            cambio = true;
        }
    
    if (Total  != venta.Total)
        {
            Total = venta.Total;
            cambio= true;
        }
        if (UsuarioId != venta.UsuarioId) { 
        UsuarioId= venta.UsuarioId;
            cambio = true;
        }

        if(ProductoId  != venta.ProductoId)
        {

            ProductoId= venta.ProductoId;
            cambio = true;
        }
        if (ClienteId != venta.ClienteId) { 
        
        ClienteId= venta.ClienteId;
            cambio = true;
        }
        return cambio;
    }
    public VentaResponse ToResponse() => new VentaResponse()
    {
        NombreP = NombreP,
        DetalleV = DetalleV,
        Costo = Costo,
        Total = Total,
        Cantidad = Cantidad,
        UsuarioId = UsuarioId,
        ProductoId = ProductoId,
        ClienteId = ClienteId

    };

}
