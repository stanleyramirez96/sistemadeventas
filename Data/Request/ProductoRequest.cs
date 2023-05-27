using System.ComponentModel.DataAnnotations;

using sistemadeventas.Data.Models;
namespace sistemadeventas.Data.Request 
    {
    
    public class ProductoRequest
{
    [Key]
    public int ID { get; set; }
    public string? NombreP { get; set; }
    public decimal Costo { get; set; }
    public decimal Total { get; set; }
    public int Cantidad { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; }

} }
