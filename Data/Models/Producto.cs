using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Models;
public class Producto
{
    [Key]
    public int ID { get; set; }
    public string? NombreP { get; set; }
    public decimal PrecioV { get; set; }
    public decimal PrecioC { get; set; }
    public int Cantidad { get; set; }
    public static Producto Crear(ProductoRequest producto) => new Producto()
    {
        NombreP = producto.NombreP,
        PrecioV = producto.PrecioV, 
        PrecioC = producto.PrecioC,
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
        if (PrecioV != producto.PrecioV)
        {
            PrecioV = producto.PrecioV;
            cambio = true;
        }

        if (PrecioC != producto.PrecioC)
        {
            PrecioC = producto.PrecioC;
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
        ID=ID,
        NombreP = NombreP,
        PrecioV = PrecioV,
        PrecioC = PrecioC,
        Cantidad = Cantidad

    };
    public virtual ICollection<Venta> Ventas { get; set; }
}
