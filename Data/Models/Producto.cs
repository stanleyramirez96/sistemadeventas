namespace sistemadeventas.Data.Models;
public class Producto
{
    public int ID { get; set; }
    public string? NombreP { get; set; }
    public decimal Costo { get; set; }
    public decimal Total { get; set; }
    public int Cantidad { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; }

}
