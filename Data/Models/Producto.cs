using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Models;
public class Producto
{
    [Key]
    public int ID { get; set; }
    public string? NombreP { get; set; }
    public decimal Costo { get; set; }
    public decimal Total { get; set; }
    public int Cantidad { get; set; }
    public static Producto Crear(ProductoRequest producto) => new Producto()
    {
       NombreP = producto.NombreP,
      Costo = producto.Costo, 
        Total = producto.Total,
        Cantidad = producto.Cantidad
    };
    public bool Modificar(ProductoRequest producto)
    {

        var  cambio = false;
        
        if (NombreP != producto.NombreP)
        {

            NombreP = producto.NombreP;
            cambio = true;

        }
        if (Costo != producto.Costo)
        {
            Costo = producto.Costo;
            cambio = true;
        }

        if (Total != producto.Total)
        {
            Total = producto.Total;
            cambio = true;
        }
        if (Cantidad != producto.Cantidad)
        {
            Cantidad = producto.Cantidad;
            cambio = true;
        }
        return cambio;
    }
    public ProductoResponse ToResponse() => new ProductoResponse()
    {
        NombreP = NombreP,
        Costo = Costo,
        Total = Total,
        Cantidad = Cantidad

    };
    public virtual ICollection<Venta> Ventas { get; set; }


}
